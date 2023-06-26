package hr.algebra.iis.controller;

import hr.algebra.iis.model.Episode;
import hr.algebra.iis.model.Location;
import hr.algebra.iis.repository.EpisodeRepository;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
@AllArgsConstructor
public class EpisodeController {
    private EpisodeRepository repo;

    @GetMapping("/episodes")
    public ResponseEntity<List<Episode>> getCharacters() {
        List<Episode> episodes = new ArrayList<>(repo.findAll());
        if(episodes.isEmpty()) return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        return new ResponseEntity<>(episodes, HttpStatus.OK);
    }
}
