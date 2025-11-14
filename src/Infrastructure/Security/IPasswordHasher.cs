using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string senha);
        bool VerifyPassword(string senha, string hash);
    }
}
