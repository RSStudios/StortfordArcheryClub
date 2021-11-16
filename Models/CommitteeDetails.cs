using Piranha.Extend;
using Piranha.Extend.Fields;

namespace StortfordArchers.Models

{
    public class CommitteeDetails1

    {
        [Field(Title = "Committee ID")]
        public NumberField Id { get; set; }

        [Field(Title = "Committee Role")]
        public TextField Role { get; set; }

        [Field(Title = "Committee member")]
        public TextField MemberName { get; set; }

        [Field(Title = "Committee member email")]
        public TextField Email { get; set; }
    }
}

