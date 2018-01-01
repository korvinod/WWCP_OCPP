﻿/*
 * Copyright (c) 2014-2018 GraphDefined GmbH
 * This file is part of WWCP OCPP <https://github.com/OpenChargingCloud/WWCP_OCPP>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

#endregion

namespace org.GraphDefined.WWCP.OCPPv1_6.CP
{

    /// <summary>
    /// An OCPP CP server logger.
    /// </summary>
    public class CPServerLogger : HTTPServerLogger
    {

        #region Data

        /// <summary>
        /// The default context for this logger.
        /// </summary>
        public const String DefaultContext = "OCPP_CPServer";

        #endregion

        #region Properties

        /// <summary>
        /// The linked OCPP charge point SOAP server.
        /// </summary>
        public CPServer CPServer { get; }

        #endregion

        #region Constructor(s)

        #region CPServerLogger(CPServer, Context = DefaultContext, LogFileCreator = null)

        /// <summary>
        /// Create a new OCPP charge point SOAP server logger using the default logging delegates.
        /// </summary>
        /// <param name="CPServer">A OCPP charge point SOAP server.</param>
        /// <param name="Context">A context of this API.</param>
        /// <param name="LogFileCreator">A delegate to create a log file from the given context and log file name.</param>
        public CPServerLogger(CPServer                 CPServer,
                               String                  Context         = DefaultContext,
                               LogfileCreatorDelegate  LogFileCreator  = null)

            : this(CPServer,
                   Context.IsNotNullOrEmpty() ? Context : DefaultContext,
                   null,
                   null,
                   null,
                   null,

                   LogFileCreator: LogFileCreator)

        { }

        #endregion

        #region CPServerLogger(CPServer, Context, ... Logging delegates ...)

        /// <summary>
        /// Create a new OCPP charge point SOAP server logger using the given logging delegates.
        /// </summary>
        /// <param name="CPServer">A OCPP charge point SOAP server.</param>
        /// <param name="Context">A context of this API.</param>
        /// 
        /// <param name="LogHTTPRequest_toConsole">A delegate to log incoming HTTP requests to console.</param>
        /// <param name="LogHTTPResponse_toConsole">A delegate to log HTTP requests/responses to console.</param>
        /// <param name="LogHTTPRequest_toDisc">A delegate to log incoming HTTP requests to disc.</param>
        /// <param name="LogHTTPResponse_toDisc">A delegate to log HTTP requests/responses to disc.</param>
        /// 
        /// <param name="LogHTTPRequest_toNetwork">A delegate to log incoming HTTP requests to a network target.</param>
        /// <param name="LogHTTPResponse_toNetwork">A delegate to log HTTP requests/responses to a network target.</param>
        /// <param name="LogHTTPRequest_toHTTPSSE">A delegate to log incoming HTTP requests to a HTTP server sent events source.</param>
        /// <param name="LogHTTPResponse_toHTTPSSE">A delegate to log HTTP requests/responses to a HTTP server sent events source.</param>
        /// 
        /// <param name="LogHTTPError_toConsole">A delegate to log HTTP errors to console.</param>
        /// <param name="LogHTTPError_toDisc">A delegate to log HTTP errors to disc.</param>
        /// <param name="LogHTTPError_toNetwork">A delegate to log HTTP errors to a network target.</param>
        /// <param name="LogHTTPError_toHTTPSSE">A delegate to log HTTP errors to a HTTP server sent events source.</param>
        /// 
        /// <param name="LogFileCreator">A delegate to create a log file from the given context and log file name.</param>
        public CPServerLogger(CPServer                    CPServer,
                              String                      Context,

                              HTTPRequestLoggerDelegate   LogHTTPRequest_toConsole,
                              HTTPResponseLoggerDelegate  LogHTTPResponse_toConsole,
                              HTTPRequestLoggerDelegate   LogHTTPRequest_toDisc,
                              HTTPResponseLoggerDelegate  LogHTTPResponse_toDisc,

                              HTTPRequestLoggerDelegate   LogHTTPRequest_toNetwork    = null,
                              HTTPResponseLoggerDelegate  LogHTTPResponse_toNetwork   = null,
                              HTTPRequestLoggerDelegate   LogHTTPRequest_toHTTPSSE    = null,
                              HTTPResponseLoggerDelegate  LogHTTPResponse_toHTTPSSE   = null,

                              HTTPResponseLoggerDelegate  LogHTTPError_toConsole      = null,
                              HTTPResponseLoggerDelegate  LogHTTPError_toDisc         = null,
                              HTTPResponseLoggerDelegate  LogHTTPError_toNetwork      = null,
                              HTTPResponseLoggerDelegate  LogHTTPError_toHTTPSSE      = null,

                              LogfileCreatorDelegate      LogFileCreator              = null)

            : base(CPServer.SOAPServer,
                   Context.IsNotNullOrEmpty() ? Context : DefaultContext,

                   LogHTTPRequest_toConsole,
                   LogHTTPResponse_toConsole,
                   LogHTTPRequest_toDisc,
                   LogHTTPResponse_toDisc,

                   LogHTTPRequest_toNetwork,
                   LogHTTPResponse_toNetwork,
                   LogHTTPRequest_toHTTPSSE,
                   LogHTTPResponse_toHTTPSSE,

                   LogHTTPError_toConsole,
                   LogHTTPError_toDisc,
                   LogHTTPError_toNetwork,
                   LogHTTPError_toHTTPSSE,

                   LogFileCreator)

        {

            #region Initial checks

            if (CPServer == null)
                throw new ArgumentNullException(nameof(CPServer), "The given CP server must not be null!");

            this.CPServer = CPServer;

            #endregion


            //#region SelectEVSE

            //RegisterEvent("SelectEVSERequest",
            //              handler => CPServer.OnSelectEVSESOAPRequest += handler,
            //              handler => CPServer.OnSelectEVSESOAPRequest -= handler,
            //              "SelectEVSE", "OCPPdirect", "Requests", "All").
            //    RegisterDefaultConsoleLogTarget(this).
            //    RegisterDefaultDiscLogTarget(this);

            //RegisterEvent("SelectEVSEResponse",
            //              handler => CPServer.OnSelectEVSESOAPResponse += handler,
            //              handler => CPServer.OnSelectEVSESOAPResponse -= handler,
            //              "SelectEVSE", "OCPPdirect", "Responses", "All").
            //   RegisterDefaultConsoleLogTarget(this).
            //   RegisterDefaultDiscLogTarget(this);

            //#endregion


        }

        #endregion

        #endregion

    }

}
