using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldOne.Models
{
    public class Employee
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Required,MaxLength(100)]
        public int ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
