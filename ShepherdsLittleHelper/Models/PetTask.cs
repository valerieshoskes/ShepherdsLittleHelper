﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShepherdsLittleHelper.Models
{
    public class PetTask
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }
        public double Frequency { get; set; }
        public DateTime Deadline { get; set; }
        
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey("Pet")]
        public int PetID { get; set; }
        public virtual Pet Pet { get; set; }

        [ForeignKey("TaskType")]
        public int TaskTypeID { get; set; }
        public virtual TaskType TaskType { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}