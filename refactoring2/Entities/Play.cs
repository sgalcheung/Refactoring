using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace refactoring2.Entities
{
    // public class Play
    // {
    //     public PlayItem Hamlet { get; set; }
    //     
    //     public PlayItem As_like { get; set; }
    //     
    //     public PlayItem Othello { get; set; }
    //
    //     // public List<PlayItem> PlayItems { get; set; }
    //
    //     public Dictionary<string, PlayItem> PlayItems { get; set; } = new Dictionary<string, PlayItem>();
    // }
    //
    // public class PlayItem
    // {
    //     public string Name { get; set; }
    //
    //     public string Type { get; set; }
    // }
    
    public class Play
    {
        public string Name { get; set; }
    
        public string Type { get; set; }
        
        public Dictionary<string, Play> Plays { get; set; } = new Dictionary<string, Play>();
    }
}