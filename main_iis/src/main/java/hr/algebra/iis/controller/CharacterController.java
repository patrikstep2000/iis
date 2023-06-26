package hr.algebra.iis.controller;

import hr.algebra.iis.model.Character;
import hr.algebra.iis.model.Episode;
import hr.algebra.iis.model.Location;
import hr.algebra.iis.repository.CharacterRepository;
import hr.algebra.iis.repository.EpisodeRepository;
import hr.algebra.iis.repository.LocationRepository;
import hr.algebra.iis.utils.FileHelpers;
import hr.algebra.iis.validator.RNGValidator;
import hr.algebra.iis.validator.XSDValidator;
import hr.algebra.iis.utils.JAXBHelpers;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.xml.sax.SAXException;

import javax.xml.bind.JAXBException;
import java.io.*;
import java.util.*;

@RestController
@AllArgsConstructor
public class CharacterController {
    private CharacterRepository repo;

    private LocationRepository locationRepo;

    private EpisodeRepository episodeRepo;

    @GetMapping("/characters")
    public ResponseEntity<String> getCharacters() throws JAXBException {
        List<Character> characters = new ArrayList<>(repo.findAll());
        if(characters.isEmpty()) return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        return new ResponseEntity<>(JAXBHelpers.marshallCharacters(characters), HttpStatus.OK);
    }

    @GetMapping("/character/{id}")
    public ResponseEntity<Character> getCharacterById(@PathVariable int id) {
        try{
            Optional<Character> character = repo.findById(id);
            return character.map(value -> new ResponseEntity<>(value, HttpStatus.OK)).orElseGet(() -> new ResponseEntity<>(HttpStatus.NO_CONTENT));
        } catch (IndexOutOfBoundsException e){
            return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        }
    }

    @PostMapping(value = "/character/xsd")
    public ResponseEntity<Character> createCharacterXsd(@RequestBody String xml){
        try{
            if(XSDValidator.isValidXSD(xml, "xsd/character.xsd")){
                Character character = JAXBHelpers.unmarshalCharacter(xml);
                return new ResponseEntity<>(saveCharacter(character), HttpStatus.CREATED);
            }
            else{
                return new ResponseEntity<>(HttpStatus.NOT_ACCEPTABLE);
            }
        } catch (IOException | SAXException | JAXBException e){
            e.printStackTrace();
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PostMapping(value = "/character/rng")
    public ResponseEntity<Character> createCharacterRng(@RequestBody String xml) {
        try{
            if(RNGValidator.isValidRNG(xml)){
                Character character = JAXBHelpers.unmarshalCharacter(xml);
                return new ResponseEntity<>(saveCharacter(character), HttpStatus.CREATED);
            }
            else{
                return new ResponseEntity<>(HttpStatus.NOT_ACCEPTABLE);
            }
        } catch (IOException | JAXBException | SAXException e){
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @GetMapping(value = "/xml/validate")
    public ResponseEntity<Boolean> validateLastXml() {
        try{
            File file = FileHelpers.getFile("characters.xml");
            Scanner reader = new Scanner(file);
            StringWriter writer = new StringWriter();
            while (reader.hasNextLine()){
                writer.write(reader.nextLine().trim());
            }

            if(XSDValidator.isValidXSD(writer.toString(), "xsd/characters.xsd")){
                return new ResponseEntity<>(true, HttpStatus.OK);
            }
            return new ResponseEntity<>(false, HttpStatus.NOT_ACCEPTABLE);
        } catch (IOException | SAXException e){
            return new ResponseEntity<>(false, HttpStatus.NOT_ACCEPTABLE);
        }
    }

    private Character saveCharacter(Character character){
        Location origin = character.getOrigin();
        Location location = character.getLocation();
        List<Episode> episodes = character.getEpisodes();

        if(origin.getId() != 0){
            Location get = locationRepo.findById(origin.getId()).get();
            character.setOrigin(get);
        }
        else {
            if(!locationRepo.existsByNameAndTypeAndDimension(origin.getName(), origin.getType(), origin.getDimension())){
                Location savedOrigin = locationRepo.save(origin);
                character.setOrigin(savedOrigin);
            }
            else{
                Location get = locationRepo.getByNameAndTypeAndDimension(origin.getName(), origin.getType(), origin.getDimension());
                character.setOrigin(get);
            }
        }

        if(location.getId() != 0){
            Location get = locationRepo.findById(location.getId()).get();
            character.setLocation(get);
        }
        else {
            if(!locationRepo.existsByNameAndTypeAndDimension(location.getName(), location.getType(), location.getDimension())){
                Location savedLocation = locationRepo.save(location);
                character.setLocation(savedLocation);
            }
            else{
                Location get = locationRepo.getByNameAndTypeAndDimension(location.getName(), location.getType(), location.getDimension());
                character.setLocation(get);
            }
        }

        episodes.forEach(e -> {
            int index;
            if(e.getId() != 0){
                Episode get = episodeRepo.findById(e.getId()).get();
                index = episodes.indexOf(episodes.stream().filter(ep -> ep.getId() == e.getId()).findFirst().get());
                episodes.set(index, get);
            }
            else {
                Optional<Episode> current = episodes
                        .stream()
                        .filter(ep -> Objects.equals(ep.getName(), e.getName()))
                        .findFirst();
                index = episodes.indexOf(current.get());
                if (!episodeRepo.existsByNameAndShowDateAndEpisodeNumber(e.getName(), e.getShowDate(), e.getEpisodeNumber())) {
                    Episode savedEpisode = episodeRepo.save(e);
                    episodes.set(index, savedEpisode);
                } else {
                    Episode get = episodeRepo.getByNameAndShowDateAndEpisodeNumber(e.getName(), e.getShowDate(), e.getEpisodeNumber());
                    episodes.set(index, get);
                }
            }
        });

        return repo.save(character);
    }
}
