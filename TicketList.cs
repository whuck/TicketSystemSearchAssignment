using System;
using System.Collections.Generic;
namespace DotNetDbMidterm
{
    static class TicketList
    {
        //Static TicketList class
        //holds created tickets in 3 lists, getNextTicketID gets highest TicketID+1
        public static List<Ticket> bugs = new List<Ticket>();
        public static List<Ticket> enhancements = new List<Ticket>();
        public static List<Ticket> tasks = new List<Ticket>();
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
        public static void findTickets(string findWhat, string findWhere) {
            Console.WriteLine($"Looking for tickets with {findWhere}:\"{findWhat}\"");
            switch (findWhere) {
                case "status" :
                
                    break;
                case "priority" :
                    break;
                case "submitter" :
                    break;
            }
        }
    }
}