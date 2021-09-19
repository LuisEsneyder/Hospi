using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {   
        ///<summary>
        /// Referencia al contexto de Paciente 
        ///</summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo utiliza inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext=appContext;
        }
        public Paciente AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        public void DeletePaciente(int idPaciente)
        {
            var pacienteEncontreado=_appContext.Pacientes.FirstOrDefault(p => p.Id==idPaciente);
            if(pacienteEncontreado==null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontreado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Paciente> GetAllPaciente()
        {
            return _appContext.Pacientes;
        }

        public Paciente GetPaciente(int idPaciente)
        {
             return _appContext.Pacientes.FirstOrDefault(p => p.Id==idPaciente);
        }

        public Paciente UpdatePaciente(Paciente paciente)
        {
             var pacienteEncontreado=_appContext.Pacientes.FirstOrDefault(p => p.Id==paciente.Id);
             if (pacienteEncontreado != null)
             {
                 pacienteEncontreado.Nombre=paciente.Nombre;
                 pacienteEncontreado.Apellidos = paciente.Apellidos;
                 pacienteEncontreado.Direccion=paciente.Direccion;
                 pacienteEncontreado.Ciudad=paciente.Ciudad;
                 pacienteEncontreado.NumeroTelefono=paciente.NumeroTelefono;
                 pacienteEncontreado.Genero=paciente.Genero;
                 pacienteEncontreado.Latitud=paciente.Latitud;
                 pacienteEncontreado.Longitud=paciente.Longitud;
                 pacienteEncontreado.FechaNacimiento=paciente.FechaNacimiento;
                 pacienteEncontreado.Familiar=paciente.Familiar;
                 pacienteEncontreado.Enfermera=paciente.Enfermera;
                 pacienteEncontreado.Medico=paciente.Medico;
                 pacienteEncontreado.Historia=paciente.Historia;
                 _appContext.SaveChanges();
             }
             return pacienteEncontreado;
        }
    }
}