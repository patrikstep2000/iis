package hr.algebra.iis.validator;

import org.xml.sax.SAXException;

import javax.xml.XMLConstants;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;

import java.io.IOException;
import java.io.StringReader;

import static hr.algebra.iis.utils.FileHelpers.getFile;


public class  XSDValidator {

    public static boolean isValidXSD(String xml, String xsdPath) throws IOException, SAXException {
        Validator validator = initXSDValidator(xsdPath);
        try {
            StringReader reader = new StringReader(xml);
            validator.validate(new StreamSource(reader));
            return true;
        } catch (SAXException e) {
            System.out.println(e.getMessage());
            return false;
        }
    }

    private static Validator initXSDValidator(String xsdPath) throws SAXException {
        SchemaFactory factory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
        Source schemaFile = new StreamSource(getFile(xsdPath));
        Schema schema = factory.newSchema(schemaFile);
        return schema.newValidator();
    }
}
