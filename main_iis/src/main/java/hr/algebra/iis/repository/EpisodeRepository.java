package hr.algebra.iis.repository;

import hr.algebra.iis.model.Episode;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Date;

public interface EpisodeRepository extends JpaRepository<Episode, Integer> {
    boolean existsByNameAndShowDateAndEpisodeNumber(String name, Date showDate, String episodeNumber);
    Episode getByNameAndShowDateAndEpisodeNumber(String name, Date showDate, String episodeNumber);
}
