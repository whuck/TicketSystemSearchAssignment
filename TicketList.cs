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
            //Console.WriteLine($"Looking for tickets with {findWhere}:\"{findWhat}\"");
            List<Ticket> results = new List<Ticket>();
            List<Ticket> foundBugs = new List<Ticket>();
            List<Ticket> foundEnh = new List<Ticket>();
            List<Ticket> foundTask = new List<Ticket>();
            //var results;
            switch (findWhere) {
                case "status" :
                    foundBugs = bugs.Where(t => t.Status.Contains(findWhat)).ToList<Ticket>();
                    foundEnh = enhancements.Where(t => t.Status.Contains(findWhat)).ToList<Ticket>();
                    foundTask = tasks.Where(t => t.Status.Contains(findWhat)).ToList<Ticket>();
                    results = foundBugs.Concat(foundEnh).Concat(foundTask).ToList<Ticket>();
                    break;
                case "priority" :
                    foundBugs = bugs.Where(t => t.Priority.Contains(findWhat)).ToList<Ticket>();
                    foundEnh = enhancements.Where(t => t.Priority.Contains(findWhat)).ToList<Ticket>();
                    foundTask = tasks.Where(t => t.Priority.Contains(findWhat)).ToList<Ticket>();
                    results = foundBugs.Concat(foundEnh).Concat(foundTask).ToList<Ticket>();
                    break;
                case "submitter" :
                    foundBugs = bugs.Where(t => t.Submitter.Contains(findWhat)).ToList<Ticket>();
                    foundEnh = enhancements.Where(t => t.Submitter.Contains(findWhat)).ToList<Ticket>();
                    foundTask = tasks.Where(t => t.Submitter.Contains(findWhat)).ToList<Ticket>();
                    results = foundBugs.Concat(foundEnh).Concat(foundTask).ToList<Ticket>();                
                    break;
                default : break;
            }
            return results;
        }
    }
}