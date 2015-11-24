/**
 *  File Name: Fault.cs
 *  Class the hold the faults 
 *
 *  Revision History:
 *      23-Nov-2015: Wrote code
 *      24-Nov-2015: Fixed standards
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerScramble
{
    class Fault
    {
    }

    [DataContract]
    public class GameIsNotBeingHostedFault
    {
        [DataMember]
        public string Reason = "Game is not being hosted";
    }
}
