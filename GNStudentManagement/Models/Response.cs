using System.Data;

namespace GNStudentManagement.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }
}
