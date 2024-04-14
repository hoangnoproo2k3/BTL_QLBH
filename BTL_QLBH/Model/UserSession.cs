using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBH.Model
{
    internal class UserSession
    {
        private static UserSession _instance;
        public User LoggedInUser { get; private set; }

        // Khai báo một private constructor để ngăn việc tạo ra các thể hiện mới
        private UserSession() { }

        // Phương thức static để truy cập vào thể hiện duy nhất của lớp
        public static UserSession Instance
        {
            get
            {
                // Nếu chưa có thể hiện, tạo mới
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        // Phương thức để đặt thông tin người dùng đã đăng nhập
        public void SetLoggedInUser(User user)
        {
            LoggedInUser = user;
        }
        internal void ClearCurrentUser()
        {
            LoggedInUser = null;
        }
    }
}
