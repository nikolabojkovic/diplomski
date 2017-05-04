using DiplomskiCore1.Repository;
using System;
using System.Collections.Generic;
using DiplomskiCore1.Data;
using DiplomskiCore1.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomskiCore1.Models.NewModels
{
    public class Action
    {
        #region Properties
        public int HistoryId { get; set; }

        public int EndHistoryId { get; set; }

        public ActionType ActionType { get; set; }

        public DateTime ActionDate { get; set; }

        // is here because primary key is defined in appDbContext class
        public string EntityId { get; set; }

        // is here because primary key if defined in appDbContext class
        public string AuthorId { get; set; } 

        public virtual ApplicationUser Author { get; set; }

        #endregion Properties
    }
}
