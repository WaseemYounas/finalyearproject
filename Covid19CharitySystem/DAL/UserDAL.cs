using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19CharitySystem.DAL
{
    public class UserDAL
    {
        #region User
        public List<User> getUsersList()
        {
            List<User> Users;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                Users = db.User.ToList();
            }

            return Users;
        }

        public User getUserById(int _Id)
        {
            User User;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                User = db.User.FirstOrDefault(x => x.Id == _Id);
            }

            return User;
        }

        public bool AddUser(User _User)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.User.Add(_User);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateUser(User _User)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Entry(_User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }

        public void DeleteUser(int _id)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.User.Remove(db.User.FirstOrDefault(x => x.Id == _id));
                db.SaveChanges();
            }
        }
        public User Login(string email, string password)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                User obj = db.User.Where(x => x.Email == email && x.Password == password&&x.IsActive==1).FirstOrDefault();
                return obj;
            }
        }
        #endregion

        #region Donation
        public List<Donation> getDonationsList()
        {
            List<Donation> Donations;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                Donations = db.Donation.ToList();
            }

            return Donations;
        }

        public Donation getDonationById(int _Id)
        {
            Donation Donation;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                Donation = db.Donation.FirstOrDefault(x => x.Id == _Id);
            }

            return Donation;
        }

        public bool AddDonation(Donation _Donation)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Donation.Add(_Donation);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateDonation(Donation _Donation)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Entry(_Donation).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }

        public bool DeleteDonation(int _id)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Donation.Remove(db.Donation.FirstOrDefault(x => x.Id == _id));
                db.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Task
        public List<Task> getTasksList()
        {
            List<Task> Tasks;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                Tasks = db.Task.ToList();
            }

            return Tasks;
        }

        public Task getTaskById(int _Id)
        {
            Task Task;
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                Task = db.Task.FirstOrDefault(x => x.Id == _Id);
            }

            return Task;
        }

        public bool AddTask(Task _Task)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Task.Add(_Task);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateTask(Task _Task)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Entry(_Task).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }

        public void DeleteTask(int _id)
        {
            using (CharitySystemDBContext db = new CharitySystemDBContext())
            {
                db.Task.Remove(db.Task.FirstOrDefault(x => x.Id == _id));
                db.SaveChanges();
            }
        }
        #endregion
    }
}