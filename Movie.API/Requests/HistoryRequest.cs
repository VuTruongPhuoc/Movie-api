﻿namespace Movie.API.Requests
{
    public class AddHistoryRequest
    {  
        public int FilmId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class DeleteHistoryRequest
    {

    }
}
