class Forth {
  List<int> stack = [];
  Map<String, List<Function()>> customFunctions = {};

  evaluate(String input) {
   final args = buildArgs(input);
    for (var arg in args) {
      if (arg.isEmpty) continue;
      if (int.tryParse(arg) != null) {
        stack.add(int.parse(arg));
      } else {
          parseAction(arg).call();
        }
      }
    }


  List<String> buildArgs(String input) {
    var tempArgs = input.split(' ').where((arg) => arg.isNotEmpty).toList();
    if (tempArgs.isEmpty) {
      throw Exception('No command provided');
    }
    var startIndex = 0;
    var endIndex = 0;
    for (int i = 0; i < tempArgs.length; i++) {
      if (tempArgs[i] == ':') {
        startIndex = i ;
        if (i + 1 >= tempArgs.length) {
          throw Exception('Function name missing after ":"');
        }
        String functionName = tempArgs[i + 1].toUpperCase();
        if (int.tryParse(functionName) != null)
          {
            throw Exception('Invalid definition');
          }
        List<Function()> functionActions = [];
        i += 2;
        while (i < tempArgs.length && tempArgs[i] != ';') {
          functionActions.add(parseAction(tempArgs[i]));
          i++;
        }
        if (i >= tempArgs.length || tempArgs[i] != ';') {
          throw Exception('Missing ";" to end function definition');
        }
        customFunctions[functionName] = functionActions;
        endIndex = i + 1;
        tempArgs.removeRange(startIndex, endIndex);
        i = 0;
      }
    }
    return tempArgs;
  }

  Function() parseAction(String input) {
    final command = input.toUpperCase();
      // Check for existing custom function first
    if (customFunctions.containsKey(command)) {
      final customActions = List<Function()>.from(customFunctions[command]!);
      return () {
        for (final action in customActions) {
          action();
        }
      };
    }
    // if the command is a digit, the intent is to push it to the stack
    if (isDigit(command))
      {
        return () => stack.add(int.parse(command));
      }

    switch (command) {
      case 'DUP': // Duplicate the top value on the stack
        return () {
          final value = safeAccessStack(pop:false);
          stack.add(value);
        };
      case 'DROP': // Remove the top value from the stack
        return () => safeAccessStack();
      case 'SWAP': // Swap the top two values on the stack
        return () {
          final last = safeAccessStack();
          final secondLast = safeAccessStack();
          stack.add(last);
          stack.add(secondLast);
        };
      case 'OVER': // Copy the second value on the stack and push it on top
        return () => stack.add(safeAccessStack(pop:false, index:stack.length - 2));
      case '+':
        return () {
          final b = safeAccessStack();
          final a = safeAccessStack();
          stack.add(a + b);
        };
      case '-':
        return () {
          final b = safeAccessStack();
          final a = safeAccessStack();
          stack.add(a - b);
        };
      case '*':
        return () {
          final b = safeAccessStack();
          final a = safeAccessStack();
          stack.add(a * b);
        };
      case '/':
        return () {
          final b = safeAccessStack();
          final a = safeAccessStack();
          if (b == 0) {
            throw Exception('Division by zero');
          }
          stack.add(a ~/ b);
        };
      default:
        return () => throw Exception('Unknown command');
    }
  }

  int safeAccessStack({bool pop = true, int? index}) {
    try {
      final targetIndex = index ?? stack.length - 1;

      if (pop) {
        return stack.removeAt(targetIndex);
      }

      return stack[targetIndex];
    } catch (_) {
      throw Exception('Stack empty');
    }
  }

  bool isDigit(String s) => RegExp(r'^[0-9]+$').hasMatch(s);

}

