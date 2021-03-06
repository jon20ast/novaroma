﻿using System.Collections.Generic;
using System.Linq;
using Novaroma.Interface.Model;

namespace Novaroma.Model {

    public class Media : EntityBase {
        private string _serviceName;
        private string _serviceId;
        private string _serviceUrl;
        private string _imdbId;
        private string _title;
        private string _originalTitle;
        private string _outline;
        private byte[] _poster;
        private int? _year;
        private string _credits;
        private float? _rating;
        private int? _voteCount;
        private int? _runtime;
        private string _directory;
        private VideoQuality _videoQuality;
        private string _extraKeywords;
        private string _excludeKeywords;
        private int? _minSize;
        private int? _maxSize;
        private Language? _language;
        private bool _isDeleted;
        private ICollection<MediaGenre> _genres;
        private ICollection<ServiceMapping> _serviceMappings;

        protected Media() {
            Genres = new List<MediaGenre>();
            ServiceMappings = new List<ServiceMapping>();
        }

        public string ServiceName {
            get { return _serviceName; }
            set {
                if (_serviceName == value) return;

                _serviceName = value;
                RaisePropertyChanged("ServiceName");
            }
        }

        public string ServiceId {
            get { return _serviceId; }
            set {
                if (_serviceId == value) return;

                _serviceId = value;
                RaisePropertyChanged("ServiceId");
            }
        }

        public string ServiceUrl {
            get { return _serviceUrl; }
            set {
                if (_serviceUrl == value) return;

                _serviceUrl = value;
                RaisePropertyChanged("ServiceUrl");
            }
        }

        public string ImdbId {
            get { return _imdbId; }
            set {
                if (_imdbId == value) return;

                _imdbId = value;
                RaisePropertyChanged("ImdbId");
            }
        }

        public string Title {
            get { return _title; }
            set {
                if (_title == value) return;

                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string OriginalTitle {
            get { return _originalTitle; }
            set {
                if (_originalTitle == value) return;

                _originalTitle = value;
                RaisePropertyChanged("OriginalTitle");
            }
        }

        public string Outline {
            get { return _outline; }
            set {
                if (_outline == value) return;

                _outline = value;
                RaisePropertyChanged("Outline");
            }
        }

        public byte[] Poster {
            get { return _poster; }
            set {
                if (_poster == value) return;

                _poster = value;
                RaisePropertyChanged("Poster");
            }
        }

        public int? Year {
            get { return _year; }
            set {
                if (_year == value) return;

                _year = value;
                RaisePropertyChanged("_year");
            }
        }

        public string Credits {
            get { return _credits; }
            set {
                if (_credits == value) return;

                _credits = value;
                RaisePropertyChanged("Credits");
            }
        }

        public float? Rating {
            get { return _rating; }
            set {
                if (_rating == value) return;

                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        public int? VoteCount {
            get { return _voteCount; }
            set {
                if (_voteCount == value) return;

                _voteCount = value;
                RaisePropertyChanged("VoteCount");
            }
        }

        public int? Runtime {
            get { return _runtime; }
            set {
                if (_runtime == value) return;

                _runtime = value;
                RaisePropertyChanged("Runtime");
            }
        }

        public string Directory {
            get { return _directory; }
            set {
                if (_directory == value) return;

                var rootIdx = value.IndexOf(':');
                string root, path;
                if (rootIdx > 0) {
                    root = value.Substring(0, rootIdx + 1);
                    path = Helper.MakeValidDirectory(value.Substring(rootIdx + 1));
                }
                else {
                    root = string.Empty;
                    path = Helper.MakeValidDirectory(value);
                }
                value = root + path;

                _directory = value;
                RaisePropertyChanged("Directory");
            }
        }

        public VideoQuality VideoQuality {
            get { return _videoQuality; }
            set {
                if (_videoQuality == value) return;

                _videoQuality = value;
                RaisePropertyChanged("VideoQuality");
            }
        }

        public string ExtraKeywords {
            get { return _extraKeywords; }
            set {
                if (_extraKeywords == value) return;

                _extraKeywords = value;
                RaisePropertyChanged("ExtraKeywords");
            }
        }

        public string ExcludeKeywords {
            get { return _excludeKeywords; }
            set {
                if (_excludeKeywords == value) return;

                _excludeKeywords = value;
                RaisePropertyChanged("ExcludeKeywords");
            }
        }

        public int? MinSize {
            get { return _minSize; }
            set {
                if (_minSize == value) return;

                _minSize = value;
                RaisePropertyChanged("MinSize");
            }
        }

        public int? MaxSize {
            get { return _maxSize; }
            set {
                if (_minSize == value) return;

                _maxSize = value;
                RaisePropertyChanged("MaxSize");
            }
        }

        public Language? Language {
            get { return _language; }
            set {
                if (_language == value) return;

                _language = value;
                RaisePropertyChanged("Language");
            }
        }

        public bool IsDeleted {
            get { return _isDeleted; }
            set {
                if (_isDeleted == value) return;

                _isDeleted = value;
                RaisePropertyChanged("IsDeleted");
            }
        }

        public ICollection<MediaGenre> Genres {
            get { return _genres; }
            set {
                if (Equals(_genres, value)) return;

                _genres = value;
                RaisePropertyChanged("Genres");
            }
        }

        public ICollection<ServiceMapping> ServiceMappings {
            get { return _serviceMappings; }
            set {
                if (Equals(_serviceMappings, value)) return;

                _serviceMappings = value;
                RaisePropertyChanged("ServiceMappings");
            }
        }

        public string ImdbUrl {
            get {
                return string.IsNullOrEmpty(ImdbId) ? string.Empty : string.Format(Constants.ImdbTitleUrl, ImdbId);
            }
        }

        protected void CopyFrom(Media media) {
            ServiceName = media.ServiceName;
            ServiceId = media.ServiceId;
            ServiceUrl = media.ServiceUrl;
            ImdbId = media.ImdbId;
            Title = media.Title;
            OriginalTitle = media.OriginalTitle;
            Outline = media.Outline;
            Poster = media.Poster;
            Year = media.Year;
            Credits = media.Credits;
            Rating = media.Rating;
            VoteCount = media.VoteCount;
            Runtime = media.Runtime;
            Directory = media.Directory;
            VideoQuality = media.VideoQuality;
            ExtraKeywords = media.ExtraKeywords;
            ExcludeKeywords = media.ExcludeKeywords;
            MinSize = media.MinSize;
            MaxSize = media.MaxSize;
            Language = media.Language;
            IsDeleted = media.IsDeleted;

            CopyGenres(media);
            CopyServiceMappings(media);
        }

        private void CopyGenres(Media media) {
            var c = Genres.Count;
            var ec = media.Genres.Count;
            while (c > ec) Genres.Remove(Genres.ElementAt(--c));

            for (var i = 0; i < ec; i++) {
                MediaGenre genre;
                if (c < i + 1) {
                    genre = new MediaGenre();
                    Genres.Add(genre);
                }
                else
                    genre = Genres.ElementAt(i);

                genre.CopyFrom(media.Genres.ElementAt(i));
            }
        }

        private void CopyServiceMappings(Media media) {
            var c = ServiceMappings.Count;
            var ec = media.ServiceMappings.Count;
            while (c > ec) ServiceMappings.Remove(ServiceMappings.ElementAt(--c));

            for (var i = 0; i < ec; i++) {
                ServiceMapping serviceMapping;
                if (c < i + 1) {
                    serviceMapping = new ServiceMapping();
                    ServiceMappings.Add(serviceMapping);
                }
                else
                    serviceMapping = ServiceMappings.ElementAt(i);

                serviceMapping.CopyFrom(media.ServiceMappings.ElementAt(i));
            }
        }

        protected override void CopyFrom(IEntity entity) {
            var external = Helper.ConvertTo<Media>(entity);

            CopyFrom(external);
        }
    }
}
