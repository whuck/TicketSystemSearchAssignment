using System;
using System.Collections.Generic;
using System.Linq;

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
        public static List<Ticket> FindTickets(string findWhat, string findWhere) {
            List<Ticket> results = new List<Ticket>();
            switch (findWhere) {
                case "status" :
                    results = bugs.Where(t => t.Status.Contains(findWhat))
                        .Concat(enhancements.Where(t => t.Status.Contains(findWhat)))
                        .Concat(tasks.Where(t => t.Status.Contains(findWhat))).ToList<Ticket>();
                    break;
                case "priority" :
                    results = bugs.Where(t => t.Priority.Contains(findWhat))
                        .Concat(enhancements.Where(t => t.Priority.Contains(findWhat)))
                        .Concat(tasks.Where(t => t.Priority.Contains(findWhat))).ToList<Ticket>();
                    break;
                case "submitter" :
                    results = bugs.Where(t => t.Submitter.Contains(findWhat))
                        .Concat(enhancements.Where(t => t.Submitter.Contains(findWhat)))
                        .Concat(tasks.Where(t => t.Submitter.Contains(findWhat))).ToList<Ticket>();             
                    break;
                default : break;
            }
            return results;
        }
    }
}