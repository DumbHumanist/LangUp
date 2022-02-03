using System;
using System.Collections.Generic;

namespace ServerLangUp.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string MainLanguge { get; set; }
        public string LearnedLanguage { get; set; }
        public string Exercises { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; } 
        public User Creator { get; set; }
    }
}
