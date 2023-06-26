package hr.algebra.iis.utils;

import hr.algebra.iis.model.Character;
import hr.algebra.iis.model.Characters;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import java.io.IOException;
import java.io.StringReader;
import java.io.StringWriter;
import java.util.List;

public class JAXBHelpers {
    public static Character unmarshalCharacter(String xml) throws JAXBException, IOException {
        JAXBContext context = JAXBContext.newInstance(Character.class);
        return (Character) context.createUnmarshaller().unmarshal(new StringReader(xml));
    }

    public static String marshallCharacters(List<Character> charactersList) throws JAXBException {
        Characters characters = new Characters();
        characters.setCharacters(charactersList);
        JAXBContext context = JAXBContext.newInstance(Characters.class);
        Marshaller marshaller = context.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        StringWriter writer = new StringWriter();
        marshaller.marshal(characters, writer);
        return writer.toString();
    }
}
