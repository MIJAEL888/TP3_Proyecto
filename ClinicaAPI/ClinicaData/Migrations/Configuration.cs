using System.Data.Entity.Core.Metadata.Edm;
using ClinicaEntity;
using ClinicaUtil;

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
                    Nombre = "Nombre Paciente 3",
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
                    Id = 4,
                    Nombre = "Nombre paciente 4",
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
                    Id = 5,
                    Nombre = "Nombre Paciente 5",
                    FechaNacimiento = new DateTime(1990, 05, 14),
                    IdUsuario = 1,
                    Correo = "mijael888@gmail.com",
                    Direccion = "ate",
                    NumeroDocumento = "1451897",
                    TipoDocumento = "DNI",
                    Telefono = "123456",
                    Sexo = "M"
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

            context.Personas.AddOrUpdate(d => d.Id,
                new Persona
                {
                    Id = 1,
                    Nombre = "Nombre Persona 1",
                    Apellido = "Apellido persona 1",
                    TipoDocumento = TipoDocumento.Dni.ToString(),
                    NumeroDocumento = "12345678",
                    Sexo = "M",
                    Telefono = "01234445",
                    Direccion = "Direccion 1",
                    Correo = "xyz@gmail.com"
                },
                new Persona
                {
                    Id = 2,
                    Nombre = "Nombre Persona 2",
                    Apellido = "Apellido persona 2",
                    TipoDocumento = TipoDocumento.Dni.ToString(),
                    NumeroDocumento = "22345678",
                    Sexo = "M",
                    Telefono = "02234445",
                    Direccion = "Direccion 2",
                    Correo = "xyz@gmail.com"
                },
                new Persona
                {
                    Id = 3,
                    Nombre = "Nombre Persona 3",
                    Apellido = "Apellido persona 3",
                    TipoDocumento = TipoDocumento.Dni.ToString(),
                    NumeroDocumento = "32345678",
                    Sexo = "F",
                    Telefono = "03234445",
                    Direccion = "Direccion 3",
                    Correo = "xyz@gmail.com"
                },
                new Persona
                {
                    Id = 4,
                    Nombre = "Nombre Persona 4",
                    Apellido = "Apellido persona 4",
                    TipoDocumento = TipoDocumento.Dni.ToString(),
                    NumeroDocumento = "42345678",
                    Sexo = "F",
                    Telefono = "04234445",
                    Direccion = "Direccion 4",
                    Correo = "xyz@gmail.com"
                },
                new Persona
                {
                    Id = 5,
                    Nombre = "Nombre Persona 5",
                    Apellido = "Apellido persona 5",
                    TipoDocumento = TipoDocumento.Dni.ToString(),
                    NumeroDocumento = "52345678",
                    Sexo = "M",
                    Telefono = "05234445",
                    Direccion = "Direccion 5",
                    Correo = "xyz@gmail.com"
                }
            );
            context.Areas.AddOrUpdate(d => d.Id,
                new Area
                {
                    Id = 1,
                    Nombre = "UCI"
                },
                new Area
                {
                    Id = 2,
                    Nombre = "Hospitalizacion"
                },
                new Area
                {
                    Id = 3,
                    Nombre = "Admision"
                }
            );
            context.Especialidades.AddOrUpdate(d => d.Id,
                new Especialidad
                {
                    Id = 1,
                    Nombre = "Especialidad 1",
                },
                new Especialidad
                {
                    Id = 2,
                    Nombre = "Especialidad 2",
                },
                new Especialidad
                {
                    Id = 3,
                    Nombre = "Especialidad 3",
                }
            );

            context.Empleados.AddOrUpdate(d => d.Id,
                new Empleado
                {
                    Id = 1,
                    IdArea = 1,
                    IdEspecialidad = 1,
                    IdPersona = 1,
                    FechaIngreso = DateTime.Now,
                    Cargo = "Doctor UCI",
                    CorreoInst = "doctoruci@abc.com",
                    Profesion = "Neurología"
                },
                new Empleado
                {
                    Id = 2,
                    IdArea = 1,
                    IdEspecialidad = 1,
                    IdPersona = 2,
                    FechaIngreso = DateTime.Now,
                    Cargo = "Doctor UCI 2",
                    CorreoInst = "doctoruci@abc.com",
                    Profesion = "Neurología"
                },
                new Empleado
                {
                    Id = 3,
                    IdArea = 1,
                    IdEspecialidad = 2,
                    IdPersona = 3,
                    FechaIngreso = DateTime.Now,
                    Cargo = "Enfermera UCI",
                    CorreoInst = "doctoruci@abc.com",
                    Profesion = "Neurología"
                },
                new Empleado
                {
                    Id = 4,
                    IdArea = 1,
                    IdEspecialidad = 3,
                    IdPersona = 4,
                    FechaIngreso = DateTime.Now,
                    Cargo = "Tecnica UCI",
                    CorreoInst = "doctoruci@abc.com",
                    Profesion = "Neurología"
                },
                new Empleado
                {
                    Id = 5,
                    IdArea = 1,
                    IdEspecialidad = 2,
                    IdPersona = 5,
                    FechaIngreso = DateTime.Now,
                    Cargo = "Enfermeria ",
                    CorreoInst = "doctoruci@abc.com",
                    Profesion = "Neurología"
                }
            );

            context.Diagnosticos.AddOrUpdate(d => d.Id,
                new Diagnostico
                {
                    Id = 1,
                    IdEmpleado = 1,
                    Descripcion = "Descripcion Diagnostico 1",
                    Nombre = "Nombre Diagnostico 1"
                },
                new Diagnostico
                {
                    Id = 2,
                    IdEmpleado = 2,
                    Descripcion = "Descripcion Diagnostico 2",
                    Nombre = "Nombre Diagnostico 2"
                },
                new Diagnostico
                {
                    Id = 3,
                    IdEmpleado = 3,
                    Descripcion = "Descripcion Diagnostico 3",
                    Nombre = "Nombre Diagnostico 3"
                },
                new Diagnostico
                {
                    Id = 4,
                    IdEmpleado = 4,
                    Descripcion = "Descripcion Diagnostico 4",
                    Nombre = "Nombre Diagnostico 4"
                },
                new Diagnostico
                {
                    Id = 5,
                    IdEmpleado = 5,
                    Descripcion = "Descripcion Diagnostico 5",
                    Nombre = "Nombre Diagnostico 5"
                }
            );

            context.Tratamientos.AddOrUpdate(d => d.Id,
                new Tratamiento
                {
                    Id = 1,
                    Nombre = "Nombre tratamiento 1",
                    Descripcion = "Descripcion Tratamiento 1",
                },
                new Tratamiento
                {
                    Id = 4,
                    Nombre = "Nombre tratamiento 4",
                    Descripcion = "Descripcion Tratamiento 4",
                },
                new Tratamiento
                {
                    Id = 2,
                    Nombre = "Nombre tratamiento 2",
                    Descripcion = "Descripcion Tratamiento 2",
                },
                new Tratamiento
                {
                    Id = 3,
                    Nombre = "Nombre tratamiento 3",
                    Descripcion = "Descripcion Tratamiento 3",
                },
                new Tratamiento
                {
                    Id = 5,
                    Nombre = "Nombre tratamiento 5",
                    Descripcion = "Descripcion Tratamiento 5",
                }
            );

            context.HistoriaClinicas.AddOrUpdate(d => d.Id,
                new HistoriaClinica
                {
                    Id = 1,
                    IdDiagnostico = 1,
                    IdTratamiento = 1,
                    IdPaciente = 1,
                    FechaRegistro = DateTime.Now,
                    Observacion = "Observaciones de la historia clinica 1",
                    GrupoSangineo = "A+",
                    Peso = "55 Kg",
                    Talla = "1.70 Mts",
                    IdNivelCriticidad = 1
                },
                new HistoriaClinica
                {
                    Id = 2,
                    IdDiagnostico = 2,
                    IdTratamiento = 2,
                    IdPaciente = 2,
                    FechaRegistro = DateTime.Now,
                    Observacion = "Observaciones de la historia clinica 1",
                    GrupoSangineo = "A+",
                    Peso = "55 Kg",
                    Talla = "1.70 Mts",
                    IdNivelCriticidad = 2
                },
                new HistoriaClinica
                {
                    Id = 3,
                    IdDiagnostico = 3,
                    IdTratamiento = 3,
                    IdPaciente = 3,
                    FechaRegistro = DateTime.Now,
                    Observacion = "Observaciones de la historia clinica 1",
                    GrupoSangineo = "A+",
                    Peso = "55 Kg",
                    Talla = "1.70 Mts",
                    IdNivelCriticidad = 3
                },
                new HistoriaClinica
                {
                    Id = 4,
                    IdDiagnostico = 4,
                    IdTratamiento = 4,
                    IdPaciente = 4,
                    FechaRegistro = DateTime.Now,
                    Observacion = "Observaciones de la historia clinica 1",
                    GrupoSangineo = "A+",
                    Peso = "55 Kg",
                    Talla = "1.70 Mts",
                    IdNivelCriticidad = 3
                },
                new HistoriaClinica
                {
                    Id = 5,
                    IdDiagnostico = 5,
                    IdTratamiento = 5,
                    IdPaciente = 5,
                    FechaRegistro = DateTime.Now,
                    Observacion = "Observaciones de la historia clinica 1",
                    GrupoSangineo = "A+",
                    Peso = "55 Kg",
                    Talla = "1.70 Mts",
                    IdNivelCriticidad = 2
                }
            );

            context.Solicitudes.AddOrUpdate(d => d.Id,
                new Solicitud
                {
                   Id = 1,
                   IdEmpleado = 1,
                   IdHistoriaClinica = 1,
                   FechaRegistro = DateTime.Now.AddDays(-1),
                   Observacion = "Observación de la solicitud de ingreso UCI",
                   Estado = EstadoSolicitud.Pendiente
                },
                new Solicitud
                {
                    Id = 2,
                    IdEmpleado = 2,
                    IdHistoriaClinica = 2,
                    FechaRegistro = DateTime.Now.AddDays(-1),
                    Observacion = "Observación de la solicitud de ingreso UCI",
                    Estado = EstadoSolicitud.Pendiente
                },
                new Solicitud
                {
                    Id = 3,
                    IdEmpleado = 1,
                    IdHistoriaClinica = 3,
                    FechaRegistro = DateTime.Now.AddDays(-1),
                    Observacion = "Observación de la solicitud de ingreso UCI",
                    Estado = EstadoSolicitud.Pendiente
                },
                new Solicitud
                {
                    Id = 4,
                    IdEmpleado = 2,
                    IdHistoriaClinica = 4,
                    FechaRegistro = DateTime.Now.AddDays(-1),
                    Observacion = "Observación de la solicitud de ingreso UCI",
                    Estado = EstadoSolicitud.Pendiente
                },
                new Solicitud
                {
                    Id = 5,
                    IdEmpleado = 1,
                    IdHistoriaClinica = 5,
                    FechaRegistro = DateTime.Now.AddDays(-1),
                    Observacion = "Observación de la solicitud de ingreso UCI",
                    Estado = EstadoSolicitud.Pendiente
                }
            );

            context.NivelCriticidades.AddOrUpdate(d => d.Id,
                new NivelCriticidad
                {
                    Id = 1,
                    Nombre = "Observacion",
                    Codigo = "OBS",
                    Descripcion = "Observacion"
                },
                new NivelCriticidad
                {
                    Id = 2,
                    Nombre = "Vigilancia Activa",
                    Codigo = "VA",
                    Descripcion = "Vigilancia Activa"
                },
                new NivelCriticidad
                {
                    Id = 3,
                    Nombre = "Vigilancia Intensiva",
                    Codigo = "VI",
                    Descripcion = "Vigilancia Intensiva"
                },
                new NivelCriticidad
                {
                    Id = 3,
                    Nombre = "Terapéutica Intensiva",
                    Codigo = "TI",
                    Descripcion = "Terapéutica Intensiva"
                }
            );

            context.FactorRiesgos.AddOrUpdate(d => d.Id,
                new FactorRiesgo
                {
                    Id = 1,
                    Nombre = "Hermodinamico",
                    Codigo = "HERMO",
                    Descripcion = "Hermodinamico",
                    ValorMaximo = 5,
                    ValorMinimo = 1,
                    Unidades = ""
                },
                new FactorRiesgo
                {
                    Id = 2,
                    Nombre = "Respiratorio",
                    Codigo = "RESP",
                    Descripcion = "Respiratorio",
                    ValorMaximo = 5,
                    ValorMinimo = 1,
                    Unidades = ""
                },
                new FactorRiesgo
                {
                    Id = 3,
                    Nombre = "Neurológico",
                    Codigo = "NEURO",
                    Descripcion = "Neurológico",
                    ValorMaximo = 5,
                    ValorMinimo = 1,
                    Unidades = ""
                },
                new FactorRiesgo
                {
                    Id = 4,
                    Nombre = "Hidrico",
                    Codigo = "HIDRA",
                    Descripcion = "Hidrico",
                    ValorMaximo = 5,
                    ValorMinimo = 1,
                    Unidades = ""
                },
                new FactorRiesgo
                {
                    Id = 5,
                    Nombre = "Temperatura",
                    Codigo = "TEM",
                    Descripcion = "Temperatura",
                    ValorMaximo = 45,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.GradosCelsius),
                    CodUnidades = TipoUnidades.GradosCelsius,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 6,
                    Nombre = "Ritmo Cardiaco",
                    Codigo = "RC",
                    Descripcion = "Ritm Cardiaco",
                    ValorMaximo = 100,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Latidos),
                    CodUnidades = TipoUnidades.Latidos,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 7,
                    Nombre = "Presion Arterial",
                    Codigo = "PES",
                    Descripcion = "Presion Arterial",
                    ValorMaximo = 45,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Latidos),
                    CodUnidades = TipoUnidades.Latidos,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 8,
                    Nombre = "Presion Aterial Media",
                    Codigo = "PAM",
                    Descripcion = "Presion Aterial Media",
                    ValorMaximo = 45,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Latidos),
                    CodUnidades = TipoUnidades.Latidos,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 9,
                    Nombre = "Presion Aterial Pulmonar",
                    Codigo = "PCP",
                    Descripcion = "Presion Aterial Pulmonar",
                    ValorMaximo = 45,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Latidos),
                    CodUnidades = TipoUnidades.Latidos,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 10,
                    Nombre = "Gasto Cardiaco",
                    Codigo = "GC",
                    Descripcion = "Gasto Cardiaco",
                    ValorMaximo = 45,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Latidos),
                    CodUnidades = TipoUnidades.Latidos,
                    Padre = 1
                },
                new FactorRiesgo
                {
                    Id = 11,
                    Nombre = "Ventilacion controlada por volumen",
                    Codigo = "TEM",
                    Descripcion = "Ventilacion controlada por volumen",
                    ValorMaximo = 30,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.VolumenMinuto),
                    CodUnidades = TipoUnidades.VolumenMinuto,
                    Padre = 2
                },
                new FactorRiesgo
                {
                    Id = 12,
                    Nombre = "Frecuencia Respiratoria",
                    Codigo = "FR",
                    Descripcion = "Frecuencia Respiratoria",
                    ValorMaximo = 30,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.RespiracionMinuto),
                    CodUnidades = TipoUnidades.RespiracionMinuto,
                    Padre = 2
                },
                new FactorRiesgo
                {
                    Id = 13,
                    Nombre = "Fraccion respiratoria de oxigeno",
                    Codigo = "FIO2",
                    Descripcion = "Fraccion respiratoria de oxigeno",
                    ValorMaximo = 15,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.MilimitroMercurio),
                    CodUnidades = TipoUnidades.MilimitroMercurio,
                    Padre = 2
                },
                new FactorRiesgo
                {
                    Id = 14,
                    Nombre = "Saturacion de Oxigeno",
                    Codigo = "TEM",
                    Descripcion = "Saturacion de Oxigeno",
                    ValorMaximo = 15,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.MilimitroMercurio),
                    CodUnidades = TipoUnidades.MilimitroMercurio,
                    Padre = 2
                },
                new FactorRiesgo
                {
                    Id = 15,
                    Nombre = "Glasgow",
                    Codigo = "GLASGOW",
                    Descripcion = "Glasgow",
                    ValorMaximo = 100,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Porcentaje),
                    CodUnidades = TipoUnidades.Porcentaje,
                    Padre = 3
                },
                new FactorRiesgo
                {
                    Id = 16,
                    Nombre = "Ramsay",
                    Codigo = "RAMSAY",
                    Descripcion = "Ramsay",
                    ValorMaximo = 100,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Porcentaje),
                    CodUnidades = TipoUnidades.Porcentaje,
                    Padre = 3
                },
                new FactorRiesgo
                {
                    Id = 17,
                    Nombre = "Modalidad SD",
                    Codigo = "MSD",
                    Descripcion = "Modalidad SD",
                    ValorMaximo = 100,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Porcentaje),
                    CodUnidades = TipoUnidades.Porcentaje,
                    Padre = 3
                },
                new FactorRiesgo
                {
                    Id = 18,
                    Nombre = "Modalidad SI",
                    Codigo = "MSI",
                    Descripcion = "Modalidad SI",
                    ValorMaximo = 100,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.Porcentaje),
                    CodUnidades = TipoUnidades.Porcentaje,
                    Padre = 3
                },
                new FactorRiesgo
                {
                    Id = 19,
                    Nombre = "Egresos",
                    Codigo = "EGRESO",
                    Descripcion = "Egresos",
                    ValorMaximo = 1000,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.MiliLitros),
                    CodUnidades = TipoUnidades.MiliLitros,
                    Padre = 4
                },
                new FactorRiesgo
                {
                    Id = 20,
                    Nombre = "Ingresos",
                    Codigo = "INGRESO",
                    Descripcion = "Ingresos",
                    ValorMaximo = 1000,
                    ValorMinimo = 0,
                    Unidades = Enum.GetName(typeof(TipoUnidades), TipoUnidades.MiliLitros),
                    CodUnidades = TipoUnidades.MiliLitros,
                    Padre = 4
                }
            );

            context.Inmuebles.AddOrUpdate(d => d.Id,
                new Inmueble
                {
                    Id = 1,
                    FechaAdquisicion = DateTime.Now.AddDays(-25),
                    Estado = "ok",
                    DesInmueble = "Descripcion inmueble 1",
                    DesTipo = "Tipo inmueble 1"
                },
                new Inmueble
                {
                    Id = 2,
                    FechaAdquisicion = DateTime.Now.AddDays(-25),
                    Estado = "ok",
                    DesInmueble = "Descripcion inmueble 2",
                    DesTipo = "Tipo inmueble 2"
                }
            );

            context.Camas.AddOrUpdate(d => d.Id,
                new Cama
                {
                    Id = 1,
                    IdInmueble = 1,
                    Estado = EstadoCama.Disponible,
                    FechaAdquisicion = DateTime.Now.AddDays(-25),
                    Descripcion = "Descripcion cama  1",
                    Tipo = "Tipo 1",
                    Marca = "Marca 1",
                    Modelo = "Modelo 1"
                },
                new Cama
                {
                    Id = 2,
                    IdInmueble = 1,
                    Estado = EstadoCama.Disponible,
                    FechaAdquisicion = DateTime.Now.AddDays(-26),
                    Descripcion = "Descripcion cama  2",
                    Tipo = "Tipo 2",
                    Marca = "Marca 2",
                    Modelo = "Modelo 2"
                },
                new Cama
                {
                    Id = 3,
                    IdInmueble = 1,
                    Estado = EstadoCama.Disponible,
                    FechaAdquisicion = DateTime.Now.AddDays(-27),
                    Descripcion = "Descripcion cama  3",
                    Tipo = "Tipo 3",
                    Marca = "Marca 3",
                    Modelo = "Modelo 3"
                },
                new Cama
                {
                    Id = 4,
                    IdInmueble = 1,
                    Estado = EstadoCama.Disponible,
                    FechaAdquisicion = DateTime.Now.AddDays(-28),
                    Descripcion = "Descripcion cama  4",
                    Tipo = "Tipo 4",
                    Marca = "Marca 4",
                    Modelo = "Modelo 4"
                },
                new Cama
                {
                    Id = 5,
                    IdInmueble = 1,
                    Estado = EstadoCama.Disponible,
                    FechaAdquisicion = DateTime.Now.AddDays(-29),
                    Descripcion = "Descripcion cama  5",
                    Tipo = "Tipo 5",
                    Marca = "Marca 5",
                    Modelo = "Modelo 5"
                }
            );
        }
    }
}
