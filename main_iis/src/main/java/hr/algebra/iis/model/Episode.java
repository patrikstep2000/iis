package hr.algebra.iis.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonIgnore;
import hr.algebra.iis.adapter.DateAdapter;
import jakarta.persistence.*;

import javax.xml.bind.annotation.*;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import java.io.Serializable;
import java.util.Date;
import java.util.Set;

@XmlRootElement(name = "episode")
@XmlType(namespace = "http://www.w3.org/2001/episode")
@Entity
@Table(name = "episode")
public class Episode implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id;

    String name;

    @JsonFormat(pattern="MMMM d, yyyy")
    Date showDate;

    String episodeNumber;

    @ManyToMany(mappedBy = "episodes")
    Set<Character> characters;

    @XmlAttribute
    public int getId() {
        return id;
    }

    @XmlElement(name = "name")
    public String getName() {
        return name;
    }

    @XmlJavaTypeAdapter(DateAdapter.class)
    public Date getShowDate() {
        return showDate;
    }

    @XmlElement(name = "episodeNumber")
    public String getEpisodeNumber() {
        return episodeNumber;
    }

    @XmlTransient
    @JsonBackReference
    public Set<Character> getCharacters() {
        return characters;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setShowDate(Date showDate) {
        this.showDate = showDate;
    }

    public void setEpisodeNumber(String episodeNumber) {
        this.episodeNumber = episodeNumber;
    }

    public void setCharacters(Set<Character> characters) {
        this.characters = characters;
    }
}
