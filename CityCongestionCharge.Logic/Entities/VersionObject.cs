//@CodeCopy
//MdStart
using System.ComponentModel.DataAnnotations;

namespace CityCongestionCharge.Logic.Entities
{
    public abstract partial class VersionObject : IdentityObject
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
//MdEnd
