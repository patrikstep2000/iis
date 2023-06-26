package hr.algebra.iis.validator;

import org.xml.sax.SAXException;

import javax.xml.XMLConstants;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import java.io.IOException;
import java.io.StringReader;

import static hr.algebra.iis.utils.FileHelpers.getFile;

public class RNGValidator {

    public static boolean isValidRNG(String xml) throws IOException, SAXException {
        Validator validator = initRNGValidator();
        try {
            StringReader reader = new StringReader(xml);
            validator.validate(new StreamSource(reader));
            return true;
        } catch (SAXException | IOException e) {
            System.out.println(e.getMessage());
            return false;
        }
    }

    private static Validator initRNGValidator() throws SAXException, IOException {
        System.setProperty(SchemaFactory.class.getName() + ":" + XMLConstants.RELAXNG_NS_URI, "com.thaiopensource.relaxng.jaxp.XMLSyntaxSchemaFactory");
        SchemaFactory factory = SchemaFactory.newInstance(XMLConstants.RELAXNG_NS_URI);
        Schema schema = factory.newSchema(getFile("rng/character.rng"));
        return schema.newValidator();
    }
}
