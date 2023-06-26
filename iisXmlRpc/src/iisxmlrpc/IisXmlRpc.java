/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package iisxmlrpc;

import java.io.IOException;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServer;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;

/**
 *
 * @author Patrik
 */
public class IisXmlRpc {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws XmlRpcException, IOException {
        System.out.println("Starting server...");
        
        WebServer server = new WebServer(3050);
        
        XmlRpcServer xmlServer = server.getXmlRpcServer();
        PropertyHandlerMapping phm = new PropertyHandlerMapping();
        phm.addHandler("Grad", Grad.class);
        xmlServer.setHandlerMapping(phm);
        
        XmlRpcServerConfigImpl config = (XmlRpcServerConfigImpl) xmlServer.getConfig();
        config.setContentLengthOptional(false);
        config.setEnabledForExtensions(true);
        
        server.start();
        System.out.println("Server listening on port 3050...");
    }
    
}
