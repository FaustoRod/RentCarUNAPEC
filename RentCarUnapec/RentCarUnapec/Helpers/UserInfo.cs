using RentCarUnapec.Core.Models.Indentity;

namespace RentCarUnapec.Helpers
{
    public sealed class UserInfo
    {
        public int EmployeeId { get; set; }
        private static UserInfo _instance;
        private static readonly object padlock = new object();

        public static UserInfo Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserInfo();
                    }
                }

                return _instance;
            }
        }

        public void SetEmployeeId(RentCarUser user)
        {
            _instance = new UserInfo()
            {
                EmployeeId = user.EmployeeId
            };
        }
    }
}