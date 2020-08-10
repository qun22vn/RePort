namespace Task_Report
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_report
    {
        public long id { get; set; }

        [StringLength(300)]
        public string UserName { get; set; }

        [StringLength(300)]
        public string AgentCode { get; set; }

        [Column(TypeName = "ntext")]
        public string Conclution { get; set; }

        [Column(TypeName = "ntext")]
        public string RequireImg { get; set; }

        [Column(TypeName = "ntext")]
        public string ConclutionImg { get; set; }

        //internal static object TopagedList(int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        public DateTime? Time { get; set; }
    }
}
