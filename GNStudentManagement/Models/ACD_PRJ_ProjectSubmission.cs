using System;

namespace GNStudentManagement.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ACD_PRJ_ProjectSubmission
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProjectSubmissionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectGroupID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubmissionLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? SubmissionRemarks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime SubmissionDate { get; set; }

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
