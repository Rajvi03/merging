using RepositoryPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPractice
{
    public interface IDoctorService : IRepository<Doctor>
    {

    }
    public class doctorService: Repository<Doctor>,IDoctorService
    {
        public doctorService(HospitalContext context,IDoctorService doctorService) : base(context)
        {

        }
    }
}
