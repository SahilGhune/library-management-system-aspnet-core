using System.Net;

namespace Library_Management_System.Models
{
    public class IssuedRecord
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Books Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}
