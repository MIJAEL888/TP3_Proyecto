using ClinicaEntity;

namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClinicaData.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClinicaData.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.TipoAtenciones.AddOrUpdate(t => t.Id,
                new TipoAtencion
                {
                    Id = 1,
                    Tipo = "Consultoria"
                },
                new TipoAtencion
                {
                    Id = 2,
                    Tipo = "Tratamiento"
                },
                new TipoAtencion
                {
                    Id = 3,
                    Tipo = "Extraccion"
                }
            );

            context.Usuarios.AddOrUpdate(u => u.Id,
                new Usuario
                {
                    Id = 1,
                    Nombre = "Mijael Palomino",
                    Contrasenia = "12345",
                    FechaCreacion = DateTime.Now
                }
            );

            context.Pacientes.AddOrUpdate(p => p.Id,
                new Paciente
                {
                    Id = 1,
                    Nombre = "Mijael Palomino",
                    FechaNacimiento = new DateTime(1990, 05, 14),
                    IdUsuario = 1,
                    Correo = "mijael888@gmail.com",
                    Direccion = "ate",
                    NumeroDocumento = "1451897",
                    TipoDocumento = "DNI",
                    Telefono = "123456",
                    Sexo = "M"
                },
                new Paciente
                {
                    Id = 2,
                    Nombre = "Familia 1",
                    FechaNacimiento = new DateTime(1990, 05, 14),
                    IdUsuario = 1,
                    Correo = "mijael888@gmail.com",
                    Direccion = "ate",
                    NumeroDocumento = "1451897",
                    TipoDocumento = "DNI",
                    Telefono = "123456",
                    Sexo = "M"
                },
                new Paciente
                {
                    Id = 3,
                    Nombre = "Familia 3",
                    FechaNacimiento = new DateTime(1990, 05, 14),
                    IdUsuario = 1,
                    Correo = "mijael888@gmail.com",
                    Direccion = "ate",
                    NumeroDocumento = "1451897",
                    TipoDocumento = "DNI",
                    Telefono = "123456"
                }
            );

            context.Doctores.AddOrUpdate(d => d.Id,
                new Doctor
                {
                    Id = 1,
                    Nombre = "Doctor 1",
                    Cargo = "Consutoria",
                    Direccion = "asdf",
                    Telefono = "1234",
                    Sexo = "M"
                },
                new Doctor
                {
                    Id = 2,
                    Nombre = "Doctor 2",
                    Cargo = "Consutoria",
                    Direccion = "asdf",
                    Telefono = "1234",
                    Sexo = "M"
                },
                new Doctor
                {
                    Id = 3,
                    Nombre = "Doctor 3",
                    Cargo = "Consutoria",
                    Direccion = "asdf",
                    Telefono = "1234",
                    Sexo = "M"
                }
            );
            context.Salas.AddOrUpdate(s => s.Id,
                new Sala
                {
                    Id = 1,
                    Codigo = "Sala1",
                    Descripcion = "Sala principal",
                    Ubicacion = "4to piso"
                },
                new Sala
                {
                    Id = 2,
                    Codigo = "Sala2",
                    Descripcion = "Sala secundaria",
                    Ubicacion = "4to piso"
                }, new Sala
                {
                    Id = 3,
                    Codigo = "Sala3",
                    Descripcion = "Sala 3ra",
                    Ubicacion = "4to piso"
                }
            );

            context.Turnos.AddOrUpdate(s => s.Id,
                new Turno
                {
                    Id = 1,
                    IdDoctor = 1,
                    IdSala = 1,
                    Observacion = "Pruebas 1 - Doc 1",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(1),
                    FechaFin = DateTime.Now.AddHours(2)
                },
                new Turno
                {
                    Id = 2,
                    IdDoctor = 1,
                    IdSala = 1,
                    Observacion = "Pruebas 2 - Doc 1",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(2),
                    FechaFin = DateTime.Now.AddHours(3)
                }, new Turno
                {
                    Id = 3,
                    IdDoctor = 1,
                    IdSala = 1,
                    Observacion = "Pruebas 3 - Doc 1",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(3),
                    FechaFin = DateTime.Now.AddHours(4)
                },
                new Turno
                {
                    Id = 4,
                    IdDoctor = 2,
                    IdSala = 2,
                    Observacion = "Pruebas 1 - Doc 2",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(1),
                    FechaFin = DateTime.Now.AddHours(2)
                },
                new Turno
                {
                    Id = 5,
                    IdDoctor = 2,
                    IdSala = 2,
                    Observacion = "Pruebas 2 - Doc 2",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(2),
                    FechaFin = DateTime.Now.AddHours(3)
                }, new Turno
                {
                    Id = 6,
                    IdDoctor = 2,
                    IdSala = 2,
                    Observacion = "Pruebas 3 - Doc 2",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(3),
                    FechaFin = DateTime.Now.AddHours(4)
                },
                new Turno
                {
                    Id = 7,
                    IdDoctor = 3,
                    IdSala = 3,
                    Observacion = "Pruebas 1 - Doc 3",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(1),
                    FechaFin = DateTime.Now.AddHours(2)
                },
                new Turno
                {
                    Id = 8,
                    IdDoctor = 3,
                    IdSala = 3,
                    Observacion = "Pruebas 2 - Doc 3",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(2),
                    FechaFin = DateTime.Now.AddHours(3)
                }, new Turno
                {
                    Id = 9,
                    IdDoctor = 3,
                    IdSala = 3,
                    Observacion = "Pruebas 3 - Doc 2",
                    EstadoTurno = EstadoTurno.Libre,
                    FechaInicio = DateTime.Now.AddHours(3),
                    FechaFin = DateTime.Now.AddHours(4)
                }
            );
            context.Citas.AddOrUpdate(p => p.Id,
                new Cita
                {
                    Id = 1,
                    IdDoctor = 1,
                    IdTipoAtencion = 1,
                    IdTurno = 1,
                    IdPaciente = 1,
                    EstadoCita = EstadoCita.Anulado,
                    Observacion = "Cita de prueba"
                },
                new Cita
                {
                    Id = 2,
                    IdDoctor = 2,
                    IdTipoAtencion = 2,
                    IdTurno = 2,
                    IdPaciente = 2,
                    EstadoCita = EstadoCita.Anulado,
                    Observacion = "Cita de prueba"
                },
                new Cita
                {
                    Id = 3,
                    IdDoctor = 3,
                    IdTipoAtencion = 3,
                    IdTurno = 3,
                    IdPaciente = 3,
                    EstadoCita = EstadoCita.Anulado,
                    Observacion = "Cita de prueba"
                }
            );

            context.Diagnosticos.AddOrUpdate(d => d.Id,
                new Diagnostico
                {

                }
            );
            context.Diagnosticos.AddOrUpdate(d => d.Id,
                new Diagnostico
                {

                }
            );

            context.Diagnosticos.AddOrUpdate(d => d.Id,
                new Diagnostico
                {
                   
                }
            );
        }
    }
}
