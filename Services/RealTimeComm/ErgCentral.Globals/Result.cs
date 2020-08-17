namespace ErgCentral.Globals
{
    public class Result
    {
        #region Public Constructors

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        #endregion Public Constructors

        #region Public Methods

        public static Result Success => new Result(true, "Success");

        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }

        public static Result Error(string errorMessage)
        {
            return new Result(true, errorMessage);
        }

        #endregion Public Methods
    }
}