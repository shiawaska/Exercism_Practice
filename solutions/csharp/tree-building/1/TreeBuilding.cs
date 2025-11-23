public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        if (records == null || !records.Any())
            throw new ArgumentException("Records cannot be null or empty");

        var orderedRecords = records.OrderBy(r => r.RecordId).ToList();
    
        // Validate record sequence and relationships
        var previousId = -1;
        foreach (var record in orderedRecords)
        {
            if ((record.RecordId == 0 && record.ParentId != 0) ||
                (record.RecordId != 0 && record.ParentId >= record.RecordId) ||
                (record.RecordId != 0 && record.RecordId != previousId + 1))
            {
                throw new ArgumentException("Invalid tree structure");
            }
            previousId++;
        }

        // Build tree with O(1) lookups
        var treeById = new Dictionary<int, Tree>();
        foreach (var record in orderedRecords)
        {
            treeById[record.RecordId] = new Tree 
            { 
                Id = record.RecordId, 
                ParentId = record.ParentId, 
                Children = new List<Tree>() 
            };
        }

        // Build parent-child relationships
        foreach (var tree in treeById.Values.Where(t => t.Id != 0))
        {
            treeById[tree.ParentId].Children.Add(tree);
        }

        return treeById[0];
    }
}