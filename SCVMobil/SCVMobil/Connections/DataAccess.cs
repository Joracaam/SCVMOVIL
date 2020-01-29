﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using SCVMobil.Models;

namespace SCVMobil
{
    //Clase utlizzada crear la base de datos de los grupos y metodos necesarios
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {

            connection = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

            connection.CreateTable<Visitas>();
           

        }
        public void 
            Visita(Visitas visita)
        {
            connection.Insert(visita);
        }
        public void UpdateVisita(Visitas visita)
        {
            connection.Update(visita);
        }
        public void DeleteVisita(Visitas visita)
        {
            connection.Delete(visita);
        }
        public Visitas GetVisita(string Cedula)
        {
            return connection.Table<Visitas>()
                .FirstOrDefault(c => c.Cedula == Cedula);
        }

        public void DeleteAllVISITAS()
        {


            connection.DeleteAll<Visitas>();

        }
        public List<Visitas> GetVisitas()
        {
            return connection.Table<Visitas>().ToList();
        }

        public void InsertReserva(VW_RESERVA_VISITA reserva)
        {
            connection.Insert(reserva);
        }
        public void UpdateReserva(VW_RESERVA_VISITA reserva)
        {
            connection.Update(reserva);
        }
        public void DeleteReserva(VW_RESERVA_VISITA reserva)
        {
            connection.Delete(reserva);
        }
        public VW_RESERVA_VISITA GetReserva(string Cedula)
        {
            return connection.Table<VW_RESERVA_VISITA>()
                .FirstOrDefault(c => c.VISITAS_DOCUMENTO == Cedula);
        }

        public void DeleteAllReservas()
        {


            connection.DeleteAll<VW_RESERVA_VISITA>();

        }
        public List<VW_RESERVA_VISITA> GetReservas()
        {
            return connection.Table<VW_RESERVA_VISITA>().ToList();
        }
        public void InsertInvitado(Invitados invitado)
        {
            connection.Insert(invitado);
        }
        public void UpdateInvitado(Invitados invitado)
        {
            connection.Update(invitado);
        }
        public void DeleteInvitado(Invitados invitado)
        {
            connection.Delete(invitado);
        }
        public Invitados GetInvitado(string invitado)
        {
            return connection.Table<Invitados>()
                .FirstOrDefault(c => c.Nombres + "" + c.Apellidos == invitado);
        }

        public List<Invitados> GetInvitados()
        {
            return connection.Table<Invitados>().ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public void InsertInvitados(List<Invitados> invitados)
        {
            foreach (Invitados registro in invitados)
            {
                connection.Insert(registro);
            }
        }

        public void InsertReserva(List<VW_RESERVA_VISITA> reser)
        {
            foreach (VW_RESERVA_VISITA registro in reser)
            {
                connection.Insert(registro);
            }
        }
        public void DeleteAllUsers()
        {


            connection.DeleteAll<VW_RESERVA_VISITA>();


        }

        public void InsertInvitado(List<Invitados> invitado)
        {
            foreach (Invitados registro in invitado)
            {
                connection.Insert(registro);
            }
        }
    }

}
