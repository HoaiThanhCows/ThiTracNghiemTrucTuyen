using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTracNghiemTrucTuyen.Shared.DTOs
{
   public record AuthensResponseDto(string Token, string? ErrorMessage = null)
    {
        public bool HasError => ErrorMessage != null;
    }
}
