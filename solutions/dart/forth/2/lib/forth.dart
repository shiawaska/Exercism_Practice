class Forth {
  List<int> stack = [];
  Map<String, List<Function()>> customFunctions = {};

  evaluate(String input) {
    final args = tokenize(input);
    execute(args);
  }

  // Executes the list of arguments by parsing each one and performing the corresponding action
  execute(List<String> args) {
    for (var arg in args) {
      if (arg.isEmpty) continue;
      parseAction(arg).call();
    }
  }

// Parses the input string and builds a list of arguments
  List<String> tokenize(String input) {
    var tokens = input.split(' ').where((arg) => arg.isNotEmpty).toList();

    if (tokens.isEmpty) {
      throw Exception('No command provided');
    }
    tokens = registerCustomFunctions(tokens);

    return tokens;
  }

// Registers custom functions defined in the input and returns the list of tokens with the function definitions removed
  List<String> registerCustomFunctions(List<String> tokens) {
    final args = List<String>.from(tokens);

    for (int i = 0; i < args.length; i++) {
      if (args[i] != ':') continue;

      final endIndex = args.indexOf(';', i);

      if (i + 1 >= args.length) {
        throw Exception('Function name missing after ":"');
      }

      if (endIndex == -1) {
        throw Exception('Missing ";" to end function definition');
      }

      final functionName = args[i + 1].toUpperCase();

      if (int.tryParse(functionName) != null) {
        throw Exception('Invalid definition');
      }

      final functionBody = args.sublist(i + 2, endIndex);
      final functionActions =
          functionBody.map((token) => parseAction(token)).toList();

      customFunctions[functionName] = functionActions;

      args.removeRange(i, endIndex + 1);
      i--;
    }

    return args;
  }

  // Parses a single command and returns a function that performs the corresponding action on the stack
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
    if (command.isDigit) {
      return () => stack.add(int.parse(command));
    }

    switch (command) {
      case 'DUP': // Duplicate the top value on the stack
        return () {
          final value = safeAccessStack(pop: false);
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
        return () =>
            stack.add(safeAccessStack(pop: false, index: stack.length - 2));
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
}

extension on String {
  bool get isDigit => int.tryParse(this) != null;
}
