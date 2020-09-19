using Covid19CharitySystem.DAL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19CharitySystem.BL
{
    public class UserBL
    {
        #region User
        public List<User> getUserList()
        {
            return new UserDAL().getUsersList();
        }

        public User getUserById(int _id)
        {
            return new UserDAL().getUserById(_id);
        }

        public int AddUser(User _User)
        {
            User emailVerify = new UserDAL().getUsersList().Where(x => x.Email == _User.Email).FirstOrDefault();
            if (emailVerify==null)
            {
                _User.CreatedAt = DateTime.Now;
                if (_User.Name != null || _User.Email != null || _User.Password != null || _User.Phone != null || _User.Address != null)
                {
                    new UserDAL().AddUser(_User);
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
           
        }

        public bool UpdateUser(User _User)
        {
            _User.CreatedAt = DateTime.Now;
            if (_User.Name == null || _User.Email == null || _User.Password == null || _User.Phone == null || _User.Address == null)
                return false;

            return new UserDAL().UpdateUser(_User);
        }
        public void DeleteUser(int _id)
        {
            new UserDAL().DeleteUser(_id);
        }
        public User Login(string email, string password)
        {
            User obj = new UserDAL().Login(email, password);
            return obj;
        }
        #endregion

        #region Donation
        public List<Donation> getDonationList()
        {
            return new UserDAL().getDonationsList();
        }

        public Donation getDonationById(int _id)
        {
            return new UserDAL().getDonationById(_id);
        }

        public bool AddDonation(Donation _Donation)
        {
            _Donation.CreatedAt = DateTime.Now;
            //if (_Donation.Name == null || _Donation.Email == null || _Donation.Password == null || _Donation.Phone == null || _Donation.Address == null)
            //    return false;
            return new UserDAL().AddDonation(_Donation);
        }

        public bool UpdateDonation(Donation _Donation)
        {
            _Donation.CreatedAt = DateTime.Now;
            //if (_Donation.Name == null || _Donation.Email == null || _Donation.Password == null || _Donation.Phone == null || _Donation.Address == null)
            //    return false;

            return new UserDAL().UpdateDonation(_Donation);
        }
        public void DeleteDonation(int _id)
        {
            new UserDAL().DeleteDonation(_id);
        }
        #endregion

        #region Task
        public List<Task> getTaskList()
        {
            return new UserDAL().getTasksList();
        }

        public Task getTaskById(int _id)
        {
            return new UserDAL().getTaskById(_id);
        }

        public bool AddTask(Task _Task)
        {
            _Task.CreatedAt = DateTime.Now;
            //if (_Task.Name == null || _Task.Email == null || _Task.Password == null || _Task.Phone == null || _Task.Address == null)
            //    return false;
            return new UserDAL().AddTask(_Task);
        }

        public bool UpdateTask(Task _Task)
        {
            _Task.CreatedAt = DateTime.Now;
            //if (_Task.Name == null || _Task.Email == null || _Task.Password == null || _Task.Phone == null || _Task.Address == null)
            //    return false;

            return new UserDAL().UpdateTask(_Task);
        }
        public void DeleteTask(int _id)
        {
            new UserDAL().DeleteTask(_id);
        }
        #endregion
    }
}