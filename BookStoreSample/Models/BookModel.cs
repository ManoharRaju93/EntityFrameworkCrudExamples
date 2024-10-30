using Microsoft.AspNetCore.Mvc;

namespace BookStoreSample.Models
{
    public class BookModel
    {
        //[FromQuery]
        public int BookId { get; set; }
        public String? Author {  get; set; }

        public override string ToString()
        {
            return $"Book object - Book Id{BookId},Author:{Author}";
        }

    }
}
