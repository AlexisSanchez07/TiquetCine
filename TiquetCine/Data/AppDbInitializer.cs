using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiquetCine.Models;

namespace TiquetCine.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cine
                if (!context.Cines.Any())
                {
                    context.Cines.AddRange(new List<Cine>()
                    {
                        new Cine()
                        {
                            Nombre = "Cinemark",
                            Foto = "https://th.bing.com/th/id/R.4644c1e621f5d1442ca32053f3630d84?rik=VR7IPOgcj2yKaw&riu=http%3a%2f%2fportal.andina.com.pe%2fEDPfotografia2%2fThumbnail%2f2009%2f04%2f27%2f000093563W.jpg&ehk=I0taLoL9WQLwpjWF%2bXnk3wi4Ib2LYlQ8qXx%2flkAurWQ%3d&risl=&pid=ImgRaw&r=0",
                            Biografia = "This is the description of the first cinema"
                        },
                        new Cine()
                        {
                            Nombre = "Cine Atlas",
                            Foto = "https://th.bing.com/th/id/OIP.O1ZT7mE8hIGYaCkZlAOQxwHaEK?rs=1&pid=ImgDetMain",
                            Biografia = "This is the description of the first cinema"
                        },
                        new Cine()
                        {
                            Nombre = "Cine Sunstar",
                            Foto = "https://th.bing.com/th/id/OIP.7b46FvC3-Dg1Ixzns-GQgAHaE8?rs=1&pid=ImgDetMain",
                            Biografia = "This is the description of the first cinema"
                        },
                        new Cine()
                        {
                            Nombre = "Cine del Solar",
                            Foto = "https://img.lagaceta.com.ar/fotos/notas/2012/08/12/505396_201208112155530000001.jpg",
                            Biografia = "This is the description of the first cinema"
                        },
                        new Cine()
                        {
                            Nombre = "Cine Hoyts",
                            Foto = "https://gvalighting.com/media/2020/06/Hoyts-scaled.jpg",
                            Biografia = "This is the description of the first cinema"
                        }                  
                    });
                    context.SaveChanges();
                }
                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Nombre = "Robert Downey Jr",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/OIP.vv5PbrtInopwBQujt5wIoQHaJG?rs=1&pid=ImgDetMain"

                        },
                        new Actor()
                        {
                            Nombre = "Hugh Jackman",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://www.lecturas.com/medio/2014/07/25/hugh_jackman_1000x1500.jpg"

                        },
                        new Actor()
                        {
                            Nombre = "Dwayne Johnson",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/R.485276458ac0a95fe3ea1405259325f9?rik=%2b%2bkL2L1i2L5guQ&riu=http%3a%2f%2fwww.hellomagazine.com%2fimagenes%2fcelebrities%2f2016082533225%2fdwayne-johnson-highest-paid-actor-forbes%2f0-169-217%2fforbes2-z.jpg&ehk=EB4txJk1ZHwWuyGRj7vJqi6IQVbtPdxRWsSD9l0cMvk%3d&risl=&pid=ImgRaw&r=0"

                        },
                        new Actor()
                        {
                            Nombre = "Will Smith",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/OIP.jJ5ylAWyrCIA05eiOCj_pwHaHa?rs=1&pid=ImgDetMain"

                        },
                        new Actor()
                        {
                            Nombre = "Christian Bale",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://www.okchicas.com/wp-content/uploads/2021/04/actores-famosos-britanicos-guapos-irresistibles-atractivos.png"

                        }
                    });
                    context.SaveChanges();
                }
                //Directores
                if (!context.Productors.Any())
                {
                    context.Productors.AddRange(new List<Productor>()
                    {
                        new Productor()
                        {
                            Nombre = "Quentin Tarantino",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://cdn.britannica.com/02/156802-050-8C6EBCC8/Quentin-Tarantino.jpg"

                        },
                        new Productor()
                        {
                            Nombre = "Martin Scorsese",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/R.53853157bf2a6e8bd8bd0ce35219ff39?rik=FfoJlFiAyQxMNQ&pid=ImgRaw&r=0"
                        },
                        new Productor()
                        {
                            Nombre = "Woody Allen",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://img.playbuzz.com/image/upload/c_crop/q_auto:good,f_auto,fl_lossy,w_640,c_limit/v1532093093/xyrinojyxyxfubobozak.jpg"
                        },
                        new Productor()
                        {
                            Nombre = "Guillermo del Toro",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/OIP.opPSS4SMqPIxBSrhI2BV4gHaEo?w=960&h=600&rs=1&pid=ImgDetMain"
                        },
                        new Productor()
                        {
                            Nombre = "Juan Jose Campanella",
                            Biografia = "This is the Bio of the first actor",
                            Foto = "https://th.bing.com/th/id/R.c4ea67da4ccf7334ad0abc8f7740b9e1?rik=QNs8ilWXhnEdlw&riu=http%3a%2f%2fwww.que.es%2farchivos%2f201301%2f5038397w-640x640x80.jpg&ehk=lHJeQCiF5z4I7FlLw4o%2bXgcMUrTnU6yQGrASzHdxiqM%3d&risl=&pid=ImgRaw&r=0"
                        }
                    });
                    context.SaveChanges();
                }
                //Peliculas
                if (!context.Peliculas.Any())
                {
                    context.Peliculas.AddRange(new List<Pelicula>()
                    {
                        new Pelicula()
                        {
                            Nombre = "Mario Bros",
                            Descripcion = "This is the Mario Bros movie description",
                            Precio = 39.50,
                            ImageURL = "https://todoinfantil.com/img/pelicula/Pelicula-infantil-Super-Mario-Bros-la-pelicula-info.jpg",
                            FechaInicio = DateTime.Now.AddDays(-10),
                            FechaFinal = DateTime.Now.AddDays(0),
                            CineId = 3,
                            ProductorId = 3,
                            Categoria = Categoria.Animada
                        },
                        new Pelicula()
                        {
                            Nombre = "The Joker",
                            Descripcion = "This is the Joker movie description",
                            Precio = 49.50,
                            ImageURL = "https://centrocomercialcamaretas.com/wp-content/uploads/2022/10/joker.jpg",
                            FechaInicio = DateTime.Now.AddDays(-10),
                            FechaFinal = DateTime.Now.AddDays(7),
                            CineId = 1,
                            ProductorId = 2,
                            Categoria = Categoria.Drama
                        },
                        new Pelicula()
                        {
                            Nombre = "Batman",
                            Descripcion = "This is the Batman movie description",
                            Precio = 42.00,
                            ImageURL = "https://circusa.com/wp-content/uploads/2022/02/p-thebatman.jpg",
                            FechaInicio = DateTime.Now.AddDays(-7),
                            FechaFinal = DateTime.Now.AddDays(20),
                            CineId = 2,
                            ProductorId = 1,
                            Categoria = Categoria.Accion
                        },
                        new Pelicula()
                        {
                            Nombre = "The Marvels",
                            Descripcion = "This is the marvels movie description",
                            Precio = 32.75,
                            ImageURL = "https://delefoco.com/Uploads/Productos/13439_22548-med.jpg",
                            FechaInicio = DateTime.Now.AddDays(10),
                            FechaFinal = DateTime.Now.AddDays(20),
                            CineId = 5,
                            ProductorId = 4,
                            Categoria = Categoria.Accion
                        },
                        new Pelicula()
                        {
                            Nombre = "Donde estan las rubias",
                            Descripcion = "This is the movie description",
                            Precio = 39.50,
                            ImageURL = "https://i.pinimg.com/736x/58/c8/79/58c8798054723c63614d9746b2d2dd45.jpg",
                            FechaInicio = DateTime.Now.AddDays(-7),
                            FechaFinal = DateTime.Now.AddDays(15),
                            CineId = 4,
                            ProductorId = 5,
                            Categoria = Categoria.Comedia
                        }
                    });
                    context.SaveChanges();
                }
                //Actores y peliculas
                if (!context.ActorPeliculas.Any())
                {
                    context.ActorPeliculas.AddRange(new List<ActorPelicula>()
                    {
                        new ActorPelicula()
                        {
                            ActorId = 1,
                            PeliculaId = 1
                        },
                        new ActorPelicula()
                        {
                            ActorId = 3,
                            PeliculaId = 1
                        },

                         new ActorPelicula()
                        {
                            ActorId = 1,
                            PeliculaId = 2
                        },
                         new ActorPelicula()
                        {
                            ActorId = 4,
                            PeliculaId = 2
                        },

                        new ActorPelicula()
                        {
                            ActorId = 1,
                            PeliculaId = 3
                        },
                        new ActorPelicula()
                        {
                            ActorId = 2,
                            PeliculaId = 3
                        },
                        new ActorPelicula()
                        {
                            ActorId = 5,
                            PeliculaId = 3
                        },


                        new ActorPelicula()
                        {
                            ActorId = 2,
                            PeliculaId = 4
                        },
                        new ActorPelicula()
                        {
                            ActorId = 3,
                            PeliculaId = 4
                        },
                        new ActorPelicula()
                        {
                            ActorId = 4,
                            PeliculaId = 4
                        },


                        new ActorPelicula()
                        {
                            ActorId = 2,
                            PeliculaId = 5
                        },
                        new ActorPelicula()
                        {
                            ActorId = 3,
                            PeliculaId = 5
                        },
                        new ActorPelicula()
                        {
                            ActorId = 4,
                            PeliculaId= 5
                        },
                        new ActorPelicula()
                        {
                            ActorId = 5,
                            PeliculaId = 5
                        },


                    });
                    context.SaveChanges();
                }

            }

        }

        
    }
}
