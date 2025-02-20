namespace Web.DTO
{
    public class ApiResponseDto
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public dynamic Result { get; set; }

        public static ApiResponseDto Ok()
        {
            return new ApiResponseDto { 
                IsSuccess = true,   
                StatusCode = 200
            };
        }

        public static ApiResponseDto InternalServerError()
        {
            return new ApiResponseDto
            {
                IsSuccess = false,
                StatusCode = 500
            };
        }
    }
}
