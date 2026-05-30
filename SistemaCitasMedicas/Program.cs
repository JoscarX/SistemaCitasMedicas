using SistemaCitasMedicas.Modelos;
using SistemaCitasMedicas.Notificaciones;
using SistemaCitasMedicas.Repositorios;
using SistemaCitasMedicas.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCitasMedicas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pacienteRepository = new PacienteRepository();
            var medicoRepository = new MedicoRepository();
            var especialidadRepository = new EspecialidadRepository();
            var citaRepository = new CitaRepository();

            var pacienteService = new PacienteService(pacienteRepository);
            var medicoService = new MedicoService(medicoRepository);
            var especialidadService = new EspecialidadService(especialidadRepository);
            var citaService = new CitaService(citaRepository);

            bool continuar = true;

            while (continuar)
            {
                MostrarTitulo();

                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Registrar especialidad");
                Console.WriteLine("3. Registrar médico");
                Console.WriteLine("4. Agendar cita");
                Console.WriteLine("5. Ver citas");
                Console.WriteLine("6. Cancelar cita");
                Console.WriteLine("7. Reprogramar cita");
                Console.WriteLine("8. Enviar recordatorio");
                Console.WriteLine("9. Salir");

                Console.WriteLine();

                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine();
                        Console.WriteLine("REGISTRO DE PACIENTE");
                        Console.WriteLine("--------------------");

                        int pacienteId =
                            LeerEntero("Código del paciente: ");

                        Console.Write("Nombre completo: ");
                        string pacienteNombre = Console.ReadLine();

                        Console.Write("Teléfono: ");
                        string pacienteTelefono = Console.ReadLine();

                        Console.Write("Correo electrónico: ");
                        string pacienteEmail = Console.ReadLine();

                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();

                        var paciente = new Paciente
                        {
                            Id = pacienteId,
                            Nombre = pacienteNombre,
                            Telefono = pacienteTelefono,
                            Email = pacienteEmail,
                            Cedula = cedula
                        };

                        pacienteService.Registrar(paciente);

                        MostrarExito("Paciente registrado correctamente.");
                        Pausa();

                        break;

                    case 2:

                        Console.WriteLine();
                        Console.WriteLine("REGISTRO DE ESPECIALIDAD");
                        Console.WriteLine("------------------------");

                        int especialidadId =
                            LeerEntero("Código de especialidad: ");

                        Console.Write("Nombre de la especialidad: ");
                        string nombreEspecialidad = Console.ReadLine();

                        var especialidad = new Especialidad
                        {
                            Id = especialidadId,
                            Nombre = nombreEspecialidad
                        };

                        especialidadService.Registrar(especialidad);

                        MostrarExito("Especialidad registrada correctamente.");
                        Pausa();

                        break;

                    case 3:

                        Console.WriteLine();
                        Console.WriteLine("REGISTRO DE MÉDICO");
                        Console.WriteLine("------------------");

                        if (!especialidadService.ObtenerTodas().Any())
                        {
                            MostrarError(
                                "Debe registrar al menos una especialidad antes de registrar médicos.");

                            Pausa();
                            break;
                        }

                        int medicoId =
                            LeerEntero("Código del médico: ");

                        Console.Write("Nombre completo: ");
                        string medicoNombre = Console.ReadLine();

                        Console.Write("Teléfono: ");
                        string medicoTelefono = Console.ReadLine();

                        Console.Write("Correo electrónico: ");
                        string medicoEmail = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Especialidades disponibles:");

                        foreach (var esp in especialidadService.ObtenerTodas())
                        {
                            Console.WriteLine($"{esp.Id} - {esp.Nombre}");
                        }

                        Console.WriteLine();

                        int espId =
                            LeerEntero("Seleccione la especialidad: ");

                        var especialidadSeleccionada =
                            especialidadService.ObtenerTodas()
                                .FirstOrDefault(x => x.Id == espId);

                        if (especialidadSeleccionada == null)
                        {
                            MostrarError("Especialidad no encontrada.");
                            Pausa();
                            break;
                        }

                        var medico = new Medico
                        {
                            Id = medicoId,
                            Nombre = medicoNombre,
                            Telefono = medicoTelefono,
                            Email = medicoEmail,
                            Especialidad = especialidadSeleccionada
                        };

                        medicoService.Registrar(medico);

                        MostrarExito("Médico registrado correctamente.");
                        Pausa();

                        break;

                    case 4:

                        Console.WriteLine();
                        Console.WriteLine("AGENDAR CITA");
                        Console.WriteLine("-------------");

                        if (!pacienteService.ObtenerTodos().Any())
                        {
                            MostrarError("No existen pacientes registrados.");
                            Pausa();
                            break;
                        }

                        if (!medicoService.ObtenerTodos().Any())
                        {
                            MostrarError("No existen médicos registrados.");
                            Pausa();
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("PACIENTES");

                        foreach (var p in pacienteService.ObtenerTodos())
                        {
                            Console.WriteLine($"{p.Id} - {p.Nombre}");
                        }

                        Console.WriteLine();

                        int idPaciente =
                            LeerEntero("Seleccione un paciente: ");

                        Console.WriteLine();
                        Console.WriteLine("MÉDICOS");

                        foreach (var m in medicoService.ObtenerTodos())
                        {
                            Console.WriteLine(
                                $"{m.Id} - {m.Nombre} ({m.Especialidad.Nombre})");
                        }

                        Console.WriteLine();

                        int idMedico =
                            LeerEntero("Seleccione un médico: ");

                        DateTime fecha =
                            LeerFecha("Fecha y hora (yyyy-MM-dd HH:mm): ");

                        var pacienteSeleccionado =
                            pacienteService.ObtenerTodos()
                                .FirstOrDefault(x => x.Id == idPaciente);

                        var medicoSeleccionado =
                            medicoService.ObtenerTodos()
                                .FirstOrDefault(x => x.Id == idMedico);

                        if (pacienteSeleccionado == null ||
                            medicoSeleccionado == null)
                        {
                            MostrarError("Paciente o médico inválido.");
                            Pausa();
                            break;
                        }

                        var cita = new CitaMedica
                        {
                            Id = citaService.ObtenerTodas().Count + 1,
                            Paciente = pacienteSeleccionado,
                            Medico = medicoSeleccionado,
                            Fecha = fecha,
                            Estado = EstadoCita.Programada
                        };

                        bool resultado = citaService.Agendar(cita);

                        if (resultado)
                        {
                            MostrarExito("La cita fue agendada correctamente.");
                        }
                        else
                        {
                            MostrarError(
                                "No fue posible agendar la cita. Verifique la fecha o disponibilidad.");
                        }

                        Pausa();

                        break;

                    case 5:

                        Console.WriteLine();
                        Console.WriteLine("LISTADO DE CITAS");
                        Console.WriteLine("----------------");

                        var citas = citaService.ObtenerTodas();

                        if (!citas.Any())
                        {
                            MostrarError("No existen citas registradas.");
                            Pausa();
                            break;
                        }

                        foreach (var c in citas)
                        {
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Código       : {c.Id}");
                            Console.WriteLine($"Paciente     : {c.Paciente.Nombre}");
                            Console.WriteLine($"Médico       : {c.Medico.Nombre}");
                            Console.WriteLine($"Especialidad : {c.Medico.Especialidad.Nombre}");
                            Console.WriteLine($"Fecha        : {c.Fecha:dd/MM/yyyy HH:mm}");
                            Console.WriteLine($"Estado       : {c.Estado}");
                        }

                        Pausa();

                        break;

                    case 6:

                        Console.WriteLine();
                        Console.WriteLine("CANCELAR CITA");
                        Console.WriteLine("-------------");

                        int citaCancelar =
                            LeerEntero("Código de la cita: ");

                        Console.Write(
                            "¿Está seguro que desea cancelar la cita? (S/N): ");

                        string respuesta = Console.ReadLine();

                        if (respuesta?.ToUpper() == "S")
                        {
                            citaService.Cancelar(citaCancelar);

                            MostrarExito("Cita cancelada correctamente.");
                        }
                        else
                        {
                            MostrarError("Operación cancelada.");
                        }

                        Pausa();

                        break;

                    case 7:

                        Console.WriteLine();
                        Console.WriteLine("REPROGRAMAR CITA");
                        Console.WriteLine("----------------");

                        int citaReprogramar =
                            LeerEntero("Código de la cita: ");

                        DateTime nuevaFecha =
                            LeerFecha("Nueva fecha y hora: ");

                        citaService.Reprogramar(
                            citaReprogramar,
                            nuevaFecha);

                        MostrarExito("La cita fue reprogramada.");

                        Pausa();

                        break;

                    case 8:

                        Console.WriteLine();
                        Console.WriteLine("ENVIAR RECORDATORIO");
                        Console.WriteLine("-------------------");

                        int idRecordatorio =
                            LeerEntero("Código de la cita: ");

                        var citaRecordatorio =
                            citaService.ObtenerTodas()
                                .FirstOrDefault(x => x.Id == idRecordatorio);

                        if (citaRecordatorio == null)
                        {
                            MostrarError("No existe una cita con ese código.");
                            Pausa();
                            break;
                        }

                        var recordatorioService =
                            new RecordatorioService(
                                new EmailNotificador());

                        recordatorioService.EnviarRecordatorio(citaRecordatorio);

                        MostrarExito("Recordatorio enviado correctamente.");

                        Pausa();

                        break;

                    case 9:

                        continuar = false;

                        Console.WriteLine();
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        Console.WriteLine("Hasta pronto.");

                        break;

                    default:

                        MostrarError("La opción seleccionada no es válida.");

                        Pausa();

                        break;
                }
            }
        }

        private static void MostrarTitulo()
        {
            Console.Clear();

            Console.WriteLine("=========================================");
            Console.WriteLine("      SISTEMA DE CITAS MÉDICAS");
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }

        private static int LeerEntero(string mensaje)
        {
            int valor;

            while (true)
            {
                Console.Write(mensaje);

                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }

                Console.WriteLine("Debe ingresar un número válido.");
                Console.WriteLine();
            }
        }

        private static DateTime LeerFecha(string mensaje)
        {
            DateTime fecha;

            while (true)
            {
                Console.Write(mensaje);

                if (DateTime.TryParse(Console.ReadLine(), out fecha))
                {
                    return fecha;
                }

                Console.WriteLine("Fecha inválida.");
                Console.WriteLine("Ejemplo: 2026-06-15 14:30");
                Console.WriteLine();
            }
        }

        private static void MostrarExito(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine($"[OK] {mensaje}");
        }

        private static void MostrarError(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine($"[ERROR] {mensaje}");
        }

        private static void Pausa()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
