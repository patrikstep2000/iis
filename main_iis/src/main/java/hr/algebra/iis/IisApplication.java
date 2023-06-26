package hr.algebra.iis;

import hr.algebra.iis.model.Character;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.SchemaOutputResolver;
import java.io.IOException;


@SpringBootApplication
public class IisApplication {

	public static void main(String[] args){
		SpringApplication.run(IisApplication.class, args);
	}

}
