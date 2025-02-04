﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.API.Requests
{
    public class AddFilmRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string OriginName { get; set; }
        public string Time { get; set; }
        public int Year { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Trailer { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public List<int> CategoryIds { get; set; }
    }
    public class UpdateFilmRequest
    {
        public string Name { get; set; }
        public string Slug {  set; get; }
        public string Description { get; set; }
        public string OriginName { get; set; }
        public string Time { get; set; }
        public int Year { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Trailer { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public List<int> CategoryIds { get; set; }
    }
    public class DeleteFilmRequest
    {

    }
    public class ChangeFilmImageRequest
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
    public class ChangeFilmPosterRequest
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile PosterFile { get; set; }
    }
}
