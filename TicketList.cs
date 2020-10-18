using System;
using System.Collections.Generic;
using System.IO;
namespace DotNetDbMidterm
{
    static class TicketList
    {
        public static List<Ticket> bugs = new List<Ticket>();
        public static List<Ticket> enhancements = new List<Ticket>();
        public static List<Ticket> tasks = new List<Ticket>();
        // static TicketList() {
        //     bugs = new List<Ticket>();
        //     enhancements = new List<Ticket>();
        //     tasks = new List<Ticket>();
        // }
        public static int getNextTicketID(string whichList) {
            int newID = 0;
            switch (whichList) {
                case "bugs" :
                    foreach(Ticket t in bugs) {
                        if(t.TicketID > newID) { newID = t.TicketID; }
                    }
                    break;
                case "enhancements" :
                    foreach(Ticket t in enhancements) {
                        if(t.TicketID > newID) { newID = t.TicketID; }
                    }
                    break;
                case "tasks" :
                    foreach(Ticket t in tasks) {
                        if(t.TicketID > newID) { newID = t.TicketID; }
                    }
                    break;
            }
            return newID+1;
        }
    }
}