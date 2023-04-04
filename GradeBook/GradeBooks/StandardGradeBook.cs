using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isweighted) : base(name,isweighted)
        {
            Type = GradeBookType.Standard;
        }
    }
}
