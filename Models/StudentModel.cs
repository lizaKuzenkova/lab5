using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab5.Views.Students {
    public class StudentModel {
        public int Id { get; set; }

        [Required]
        public string lastname { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public int groupnum { get; set; }
        [Required]
        public int missedhours { get; set; }

        public StudentModel() {
            Id = -1;
            lastname = "no lastname";
            firstname = "no firstname";
            groupnum = -1;
            missedhours = -1;
        }

        public StudentModel(int id, string lastname, string firstname, int groupnum, int missedhours) {
            Id = id;
            this.lastname = lastname;
            this.firstname = firstname;
            this.groupnum = groupnum;
            this.missedhours = missedhours;
        }
    }
}