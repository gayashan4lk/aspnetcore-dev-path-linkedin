using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandonApi.Models
{
    public class BookingRangeComparer : IEqualityComparer<BookingRange>
    {
        public bool Equals([AllowNull] BookingRange x, [AllowNull] BookingRange y) 
            => x.StartAt == y.StartAt && x.EndAt == y.EndAt;

        public int GetHashCode([DisallowNull] BookingRange obj)
            => obj.StartAt.GetHashCode() ^ obj.EndAt.GetHashCode();
    }
}
