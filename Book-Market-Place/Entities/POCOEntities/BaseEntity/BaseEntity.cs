using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.POCOEntities.BaseEntity
{
    public class BaseEntity
    {
        //[Required(ErrorMessage = "این فیلد (ID)اجباری است")]
        public int ID { get; set; }
    }
}
