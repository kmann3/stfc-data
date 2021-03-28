using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFC_Web.Data
{
    public class Seeds
    {
        public static Entities.Class Class_Command = new() { Name = "Command", Id = Guid.Parse("de824ea7-0cb1-4fbb-b04e-b4b111a2ef9c") };
        public static Entities.Class Class_Engineering = new() { Name = "Engineering", Id = Guid.Parse("15a6f9a2-0b10-4f2a-970c-79680fa2f79f") };
        public static Entities.Class Class_Science = new() { Name = "Science", Id = Guid.Parse("631777d7-a81f-4eca-807a-5f45296f2c9d") };

        public static Entities.Tags Tag_Federation = new() { Name = "Federation", Id = Guid.Parse("aa374c8d-36eb-4812-b7b6-87586ad85346") };
        public static Entities.Tags Tag_ShieldHealth = new() { Name = "Shield Health", Id = Guid.Parse("a4df0299-b0b2-422a-8792-0a0fc1cdaeb1") };

        public static Entities.Officer Officer_OneOfTen = new()
        {
            Id = Guid.Parse("68aa72df-cc98-418b-a195-b7bd5100de74"),
            Name = "One of Ten",
            Class = Class_Command,
            Tags = new List<Entities.Tags>() { Tag_Federation, Tag_ShieldHealth }
        };
    }
}
