using Cinema.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Services
{
    public interface IMovieService
    {
        bool AddMovie(MovieAddDto movieAddDto);
        int UpdateMovie(MovieUpdateDto movieUpdateDto);
        int MakeDiscount(int id);

        int DeleteMovie(int id);

        MovieDto GetMovie(int id);

        List<MovieDto> GetAllMovies();


    }
}
