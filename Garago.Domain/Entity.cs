using System;

namespace Garago.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool DeletedInd { get; set; }
        public bool PermanentlyDeletedInd { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime PermanentlyDeletedAt { get; set; }
    }
}
