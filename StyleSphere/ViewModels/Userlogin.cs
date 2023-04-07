namespace StyleSphere.ViewModels
{
    public class UserloginResponse
    {
        public UserloginResponse() 
        {
             ErrorMessage = string.Empty;  
        }

        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
