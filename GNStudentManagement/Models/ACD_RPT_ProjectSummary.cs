using System;

namespace GNStudentManagement.Models
{
    public class ACD_RPT_ProjectSummary
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProjectGroupID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectGroupName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AverageCPI { get; set; }  
        /// <summary>
        /// 
        /// </summary>
        public int ProjectTypeID { get; set; }
    
      /// <summary>
      /// 
      /// </summary>
        public int? GuideStaffID { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Modified { get; set; }   
    }
}
