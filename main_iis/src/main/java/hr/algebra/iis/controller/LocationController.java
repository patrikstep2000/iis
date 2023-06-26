package hr.algebra.iis.controller;

import hr.algebra.iis.model.Character;
import hr.algebra.iis.model.Location;
import hr.algebra.iis.repository.LocationRepository;
import hr.algebra.iis.utils.JAXBHelpers;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.xml.bind.JAXBException;
import java.util.ArrayList;
import java.util.List;

@RestController
@AllArgsConstructor
public class LocationController {
    private LocationRepository repo;

    @GetMapping("/locations")
    public ResponseEntity<List<Location>> getCharacters() {
        List<Location> locations = new ArrayList<>(repo.findAll());
        if(locations.isEmpty()) return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        return new ResponseEntity<>(locations, HttpStatus.OK);
    }
}
